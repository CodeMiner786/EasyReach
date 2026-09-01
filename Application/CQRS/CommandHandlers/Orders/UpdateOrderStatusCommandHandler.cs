using EasyReach_Application.CQRS.Commands.Orders;
using EasyReach_Application.Emails;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.NotificationMessages;
using EasyReach_Domain.Entities.Orders;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.Orders
{
    public class UpdateOrderStatusCommandHandler(
        IOrderRepository orderRepository,
        INotificationQueue notificationQueue,
        ILogger<UpdateOrderStatusCommandHandler> logger) : IRequestHandler<UpdateOrderStatusCommand, bool>
    {
        public async Task<bool> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.GetOrderWithDetailsAsync(request.OrderId);
            if (order is null) return false;

            // ১. স্ট্যাটাস এবং প্রসেসড ইউজারের আইডি আপডেট
            order.Status = request.Status;
            order.ProcessedByUserId = request.ProcessedByUserId;

            if (request.PaymentStatus.HasValue)
            {
                order.PaymentStatus = request.PaymentStatus.Value;
            }

            // ২. অর্ডার হিস্ট্রি লগ যুক্ত করা
            order.StatusHistory.Add(new OrderStatusHistory
            {
                OrderId = order.Id,
                Status = request.Status,
                Note = request.Note ?? $"Order status changed to {request.Status}"
            });

            orderRepository.Update(order);
            await orderRepository.SaveChangesAsync();

            // ৩. ব্যাকগ্রাউন্ড ইন-মেমোরি কিউতে নোটিফিকেশন পাঠানো
            try
            {
                string customerPhone = order.ShippingAddress?.Phone ?? "";
                string customerEmail = order.ShippingAddress?.Email ?? "";

                if (!string.IsNullOrEmpty(customerPhone) || !string.IsNullOrEmpty(customerEmail))
                {
                    string smsMessage = $"Dear Customer, your order #{order.OrderNumber} status is now: {request.Status}. Thank you for shopping with EasyReach!";
                    string emailSubject = $"Order #{order.OrderNumber} Status Updated - EasyReach";
                    string emailBody = $@"
                        <h2>Order Status Update</h2>
                        <p>Your order <strong>#{order.OrderNumber}</strong> status has been changed to <strong>{request.Status}</strong>.</p>
                        {(string.IsNullOrWhiteSpace(request.Note) ? "" : $"<p><strong>Note:</strong> {request.Note}</p>")}
                        <p>Thank you for shopping with us!</p>";

                    await notificationQueue.QueueNotificationAsync(new NotificationMessage(
                        PhoneNumber: customerPhone,
                        Email: customerEmail,
                        SmsBody: smsMessage,
                        EmailSubject: emailSubject,
                        EmailBody: emailBody
                    ), cancellationToken);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to queue status update notification for Order #{OrderNumber}", order.OrderNumber);
            }

            return true;
        }
    }
}
