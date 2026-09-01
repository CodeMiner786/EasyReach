using EasyReach_Application.CQRS.Commands.Couriers;
using EasyReach_Application.CourierService;
using EasyReach_Application.DTOs.Couriers;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Orders;
using EasyReach_Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EasyReach_Application.CQRS.CommandHandlers.Couriers
{
    public class CreateCourierOrderCommandHandler(
        IOrderRepository orderRepository,
        ICourierService courierService,
        ILogger<CreateCourierOrderCommandHandler> logger) : IRequestHandler<CreateCourierOrderCommand, CourierBookingResponseDto>
    {
        public async Task<CourierBookingResponseDto> Handle(
            CreateCourierOrderCommand request,
            CancellationToken cancellationToken)
        {
            var order = await orderRepository.GetOrderWithDetailsAsync(request.OrderId);

            if (order is null)
            {
                return new CourierBookingResponseDto
                {
                    IsSuccess = false,
                    Message = "Order not found."
                };
            }

            var address = order.ShippingAddress;
            string fullAddressString = address is null
                ? "N/A"
                : $"{address.AddressLine}, {address.City}, {address.District} {(string.IsNullOrEmpty(address.PostalCode) ? "" : "- " + address.PostalCode)}";

            var courierRequest = new CourierOrderRequestDto
            {
                Invoice = order.OrderNumber,
                RecipientName = address?.FullName ?? "Customer",
                RecipientPhone = address?.Phone ?? "",
                RecipientAddress = fullAddressString,
                CodAmount = order.PaymentStatus == PaymentStatus.Paid ? 0 : order.GrandTotal,
                Note = order.CustomerNote ?? "Handle with care"
            };

            var response = await courierService.CreateOrderAsync(courierRequest);

            if (response.IsSuccess)
            {
                order.Status = OrderStatus.Processing;
                order.StatusHistory.Add(new OrderStatusHistory
                {
                    OrderId = order.Id,
                    Status = OrderStatus.Processing,
                    Note = $"Parcel booked via Courier. Consignment ID: {response.ConsignmentId}, Tracking Code: {response.TrackingCode}"
                });

                orderRepository.Update(order);
                await orderRepository.SaveChangesAsync();

                logger.LogInformation("Order #{OrderNumber} booked successfully. Tracking Code: {TrackingCode}",
                    order.OrderNumber, response.TrackingCode);
            }

            return response;
        }
    }
}

