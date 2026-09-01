using EasyReach_Application.CQRS.Commands.Payments;
using EasyReach_Application.DTOs.Payments;
using EasyReach_Application.Exceptions;
using EasyReach_Application.Interfaces;
using EasyReach_Application.ISslCommerzServices;
using EasyReach_Domain.Entities.Orders;
using MediatR;

namespace EasyReach_Application.CQRS.CommandHandlers.Payments
{
    public class InitiatePaymentCommandHandler(
        ISslCommerzService sslCommerzService,
        IGenericRepository<Order> orderRepository)
        : IRequestHandler<InitiatePaymentCommand, string>
    {
        public async Task<string> Handle(InitiatePaymentCommand request, CancellationToken cancellationToken)
        {
            // ১. অর্ডার ডাটাবেজে বিদ্যমান কি না যাচাই (Simplified null check using 'is null')
            _ = await orderRepository.GetByIdAsync(request.OrderId) ?? throw new OrderNotFoundException(request.OrderId);

            // ২. কাস্টমারের তথ্য সঠিক আছে কি না ভ্যালিডেশন
            if (string.IsNullOrWhiteSpace(request.CustomerEmail) || string.IsNullOrWhiteSpace(request.CustomerPhone))
            {
                throw new InvalidCustomerInformationException("Customer email and phone number are required for SSLCommerz payment.");
            }

            var dto = new InitiateSslCommerzPaymentDto
            {
                OrderId = request.OrderId,
                CustomerName = request.CustomerName,
                CustomerEmail = request.CustomerEmail,
                CustomerAddress = request.CustomerAddress,
                CustomerPhone = request.CustomerPhone
            };

            // ৩. SSLCommerz Gateway URL রিটার্ন করবে
            return await sslCommerzService.InitiatePaymentAsync(dto);
        }
    }
}