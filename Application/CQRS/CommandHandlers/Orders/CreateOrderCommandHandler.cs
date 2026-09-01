using AutoMapper;
using EasyReach_Application.CourierService;
using EasyReach_Application.CQRS.Commands.Orders;
using EasyReach_Application.DTOs.Couriers;
using EasyReach_Application.DTOs.Orders;
using EasyReach_Application.Emails;
using EasyReach_Application.Interfaces;
using EasyReach_Application.Interfaces.CurrentUsers;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.IRedis;
using EasyReach_Application.NotificationMessages;
using EasyReach_Domain.Entities.Orders;
using EasyReach_Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.Orders
{
    public class CreateOrderCommandHandler(
        IOrderRepository orderRepository,
        IShippingAddressRepository shippingAddressRepository,
        ICartRepository cartRepository,
        ICourierService courierService,
        IMapper mapper,
        ICacheHelper cacheHelper,
        INotificationQueue notificationQueue,
        ICurrentUserService currentUserService,
        ILogger<CreateOrderCommandHandler> logger) : IRequestHandler<CreateOrderCommand, CreateOrderResponseDto>
    {
        private static readonly Regex BangladeshPhoneRegex = new(@"^01[3-9]\d{8}$", RegexOptions.Compiled);

        public async Task<CreateOrderResponseDto> Handle(
            CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            // 🚀 JWT টোকেন থেকে বর্তমান অথেনটিকেটেড ইউজারের আইডি নেওয়া
            var userId = currentUserService.UserId
                ?? throw new UnauthorizedAccessException("User is not authenticated.");

            // ১. ১১ ডিজিটের Bangladesh ফোন নম্বর ভ্যালিডেশন
            if (!BangladeshPhoneRegex.IsMatch(request.ShippingAddress.Phone))
            {
                throw new InvalidOperationException("Invalid phone number! Must be an 11-digit valid BD number.");
            }

            // ২. ২৪ ঘণ্টায় ১টি অর্ডার লিমিট চেক
            bool hasRecentOrder = await orderRepository.HasOrderInLast24HoursAsync(
                userId,
                request.ShippingAddress.Phone);

            if (hasRecentOrder)
            {
                throw new InvalidOperationException("Order limit reached! You can only place 1 order every 24 hours.");
            }

            // ৩. Steadfast Courier Ratio Check
            CourierRatioResponseDto courierRatio = await courierService.GetDeliveryRatioAsync(
                request.ShippingAddress.Phone);

            // ৪. ShippingAddress AutoMapper দিয়ে তৈরি ও সেভ
            var address = mapper.Map<ShippingAddress>(request.ShippingAddress);
            await shippingAddressRepository.AddAsync(address);
            await shippingAddressRepository.SaveChangesAsync();

            // ৫. OrderItems AutoMapper দিয়ে ম্যাপ করা
            var orderItems = mapper.Map<List<OrderItem>>(request.Items);
            decimal subTotal = orderItems.Sum(x => x.TotalPrice);

            // ৬. Order Entity তৈরি
            var order = mapper.Map<Order>(request);
            order.UserId = userId; // JWT থেকে পাওয়া UserId অ্যাসাইন করা হলো
            order.OrderNumber = $"ORD-{DateTime.UtcNow:yyyyMMdd}-{Random.Shared.Next(1000, 9999)}";
            order.ShippingAddressId = address.Id;
            order.SubTotal = subTotal;
            order.GrandTotal = subTotal + request.ShippingCharge - request.DiscountAmount;
            order.PaymentStatus = PaymentStatus.Pending;
            order.Status = OrderStatus.Pending;
            order.Items = orderItems;

            order.StatusHistory =
            [
                new OrderStatusHistory
                {
                    Status = OrderStatus.Pending,
                    Note = $"Order placed. Steadfast Courier Success Ratio: {courierRatio.SuccessRate}%"
                }
            ];

            await orderRepository.AddAsync(order);
            await orderRepository.SaveChangesAsync();

            // 🚀 ৭. অর্ডার সফল হলে ইউজারের কার্ট ক্লিন ও ক্যাশ ইনভ্যালিডেশন
            var userCartList = await cartRepository.FindAsync(c => c.UserId == userId);
            var userCart = userCartList.FirstOrDefault();
            if (userCart is not null)
            {
                cartRepository.Remove(userCart);
                await cartRepository.SaveChangesAsync();
                await cacheHelper.RemoveAsync($"cart:{userId}");
            }

            // 🚀 ৮. In-Memory Queue-তে background SMS এবং Email push
            try
            {
                var phone = request.ShippingAddress.Phone;
                var email = request.ShippingAddress.Email;

                var smsMessage = $"Dear Customer, your order #{order.OrderNumber} is placed successfully. Total: ৳{order.GrandTotal}. EasyReach.";
                var emailSubject = $"Order Confirmation #{order.OrderNumber} - EasyReach";
                var emailBody = $@"
                    <h2>Thank you for your order!</h2>
                    <p>Your order <strong>#{order.OrderNumber}</strong> has been successfully placed.</p>
                    <p><strong>Grand Total:</strong> ৳{order.GrandTotal}</p>
                    <p>We will notify you once your order is shipped.</p>";

                await notificationQueue.QueueNotificationAsync(new NotificationMessage(
                    PhoneNumber: phone,
                    Email: email,
                    SmsBody: smsMessage,
                    EmailSubject: emailSubject,
                    EmailBody: emailBody
                ), cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to queue background notification for Order #{OrderNumber}", order.OrderNumber);
            }

            return new CreateOrderResponseDto
            {
                OrderId = order.Id,
                OrderNumber = order.OrderNumber,
                GrandTotal = order.GrandTotal,
                CourierSuccessRatio = courierRatio
            };
        }
    }
}

