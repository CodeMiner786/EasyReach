using EasyReach_Application.DTOs.Payments;
using EasyReach_Application.Emails;
using EasyReach_Application.Interfaces.UnitOfWorks;
using EasyReach_Application.IRedis;
using EasyReach_Application.ISslCommerzServices;
using EasyReach_Application.NotificationMessages;
using EasyReach_Domain.Entities.Orders;
using EasyReach_Domain.Entities.Payments;
using EasyReach_Domain.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace EasyReach_Infrastructure.SslCommerzServices
{
    public class SslCommerzService(
        IUnitOfWork unitOfWork,
        IConfiguration configuration,
        HttpClient httpClient,
        ICacheLockManager lockManager,
        INotificationQueue notificationQueue,
        ILogger<SslCommerzService> logger) : ISslCommerzService
    {
        public async Task<string> InitiatePaymentAsync(InitiateSslCommerzPaymentDto dto)
        {
            var orderRepo = unitOfWork.Repository<Order>();
            var order = await orderRepo.GetByIdAsync(dto.OrderId)
                ?? throw new Exception("Order not found");

            string transactionId = $"TXN_{order.Id.ToString()[..8]}_{DateTime.UtcNow.Ticks}";

            var payment = new Payment
            {
                OrderId = order.Id,
                Amount = order.GrandTotal,
                Method = PaymentMethod.SSLCommerz,
                Status = PaymentStatus.Pending,
                TransactionId = transactionId
            };

            await unitOfWork.Payments.AddAsync(payment);
            await unitOfWork.SaveChangesAsync();

            var storeId = configuration["SslCommerzSettings:StoreId"];
            var storePassword = configuration["SslCommerzSettings:StorePassword"];
            var baseUrl = configuration["SslCommerzSettings:BaseUrl"];

            var postData = new Dictionary<string, string>
            {
                { "store_id", storeId! },
                { "store_passwd", storePassword! },
                { "total_amount", order.GrandTotal.ToString("F2") },
                { "currency", "BDT" },
                { "tran_id", transactionId },
                { "success_url", configuration["SslCommerzSettings:SuccessUrl"]! },
                { "fail_url", configuration["SslCommerzSettings:FailUrl"]! },
                { "cancel_url", configuration["SslCommerzSettings:CancelUrl"]! },
                { "ipn_url", configuration["SslCommerzSettings:IpnUrl"]! },
                { "cus_name", dto.CustomerName },
                { "cus_email", dto.CustomerEmail },
                { "cus_add1", dto.CustomerAddress },
                { "cus_phone", dto.CustomerPhone },
                { "shipping_method", "NO" },
                { "product_name", "Order Checkout" },
                { "product_category", "Ecommerce" },
                { "product_profile", "general" },
                { "multi_card_name", "bkash,nagad,mastercard,visa" }
            };

            var content = new FormUrlEncodedContent(postData);
            var response = await httpClient.PostAsync($"{baseUrl}/gwprocess/v4/api.php", content);
            var responseString = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseString);
            var root = doc.RootElement;

            if (root.TryGetProperty("status", out var status) && status.GetString() == "SUCCESS")
            {
                return root.GetProperty("GatewayPageURL").GetString()!;
            }

            logger.LogError("SSLCommerz Payment Initiation Failed: {Response}", responseString);
            throw new Exception("SSLCommerz Payment Initiation Failed");
        }

        public async Task<bool> ValidateAndCompletePaymentAsync(SslCommerzCallbackDto callbackData)
        {
            var payment = await unitOfWork.Payments.GetByTransactionIdAsync(callbackData.TranId);
            if (payment == null) return false;

            // ১. Idempotency Check: ইতিমধ্যে পেমেন্ট কমপ্লিট হয়ে গেলে স্কিপ করবে
            if (payment.Status == PaymentStatus.Completed) return true;

            // ২. Redis Lock
            string lockKey = $"locks:payment:{callbackData.TranId}";
            string? lockToken = await lockManager.AcquireLockAsync(lockKey, TimeSpan.FromSeconds(15));

            if (string.IsNullOrEmpty(lockToken))
            {
                logger.LogWarning("Payment validation request already in progress for Transaction: {TranId}", callbackData.TranId);
                return false;
            }

            // ৩. Database Transaction শুরু করা
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var storeId = configuration["SslCommerzSettings:StoreId"];
                var storePassword = configuration["SslCommerzSettings:StorePassword"];
                var baseUrl = configuration["SslCommerzSettings:BaseUrl"];

                var validationUrl = $"{baseUrl}/validator/api/validationserverAPI.php?val_id={callbackData.ValId}&store_id={storeId}&store_passwd={storePassword}&v=1&format=json";

                var response = await httpClient.GetAsync(validationUrl);
                var responseString = await response.Content.ReadAsStringAsync();

                using var doc = JsonDocument.Parse(responseString);
                var root = doc.RootElement;

                var status = root.GetProperty("status").GetString();

                payment.GatewayResponse = responseString;
                payment.ValidationId = callbackData.ValId;
                payment.BankTransactionId = callbackData.BankTranId;
                payment.CardType = callbackData.CardType;
                payment.CardIssuer = callbackData.CardIssuer;
                payment.CardBrand = callbackData.CardBrand;

                var orderRepo = unitOfWork.Repository<Order>();

                if (status == "VALID" || status == "VALIDATED")
                {
                    var order = await orderRepo.GetByIdAsync(payment.OrderId);

                    // Security Check: টাকার পরিমাণ মিলিয়ে দেখা
                    decimal paidAmount = decimal.Parse(root.GetProperty("currency_amount").GetString() ?? "0");

                    if (order != null && paidAmount < order.GrandTotal)
                    {
                        payment.Status = PaymentStatus.Failed;
                        order.PaymentStatus = PaymentStatus.Failed;

                        unitOfWork.Payments.Update(payment);
                        orderRepo.Update(order);

                        await unitOfWork.CommitTransactionAsync();
                        return false;
                    }

                    payment.Status = PaymentStatus.Completed;
                    payment.PaidAt = DateTime.UtcNow;
                    payment.StoreAmount = decimal.Parse(root.GetProperty("store_amount").GetString() ?? "0");

                    unitOfWork.Payments.Update(payment);

                    if (order != null)
                    {
                        order.PaymentStatus = PaymentStatus.Completed;
                        order.Status = OrderStatus.Paid;
                        orderRepo.Update(order);

                        // 📩 Notification Message কিউতে যুক্ত করা
                        var notification = new NotificationMessage(
                            PhoneNumber: order.ShippingAddress?.Phone ?? "",
                            Email: order.ShippingAddress?.Email ?? "customer@example.com",
                            SmsBody: $"Payment successful for Order #{order.Id}. Amount: {paidAmount} BDT. Thank you for shopping with EasyReach!",
                            EmailSubject: $"Payment Successful - Order #{order.Id}",
                            EmailBody: $"<h3>Thank you for your payment!</h3><p>Your payment of <b>{paidAmount} BDT</b> for Order #{order.Id} was successful.</p>"
                        );

                        await notificationQueue.QueueNotificationAsync(notification);
                    }

                    await unitOfWork.CommitTransactionAsync();
                    return true;
                }

                // পেমেন্ট ফেইল হলে
                payment.Status = PaymentStatus.Failed;
                unitOfWork.Payments.Update(payment);

                var failedOrder = await orderRepo.GetByIdAsync(payment.OrderId);
                if (failedOrder != null)
                {
                    failedOrder.PaymentStatus = PaymentStatus.Failed;
                    orderRepo.Update(failedOrder);
                }

                await unitOfWork.CommitTransactionAsync();
                return false;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error processing payment validation for Transaction: {TranId}", callbackData.TranId);
                await unitOfWork.RollbackTransactionAsync();
                throw;
            }
            finally
            {
                // Lock রিলিজ করা
                await lockManager.ReleaseLockAsync(lockKey, lockToken);
            }
        }
    }
}

