using EasyReach_Application.DTOs.Orders;
using EasyReach_Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.Orders
{
    public record CreateOrderCommand(
        Guid UserId,
        CreateShippingAddressDto ShippingAddress,
        PaymentMethod PaymentMethod,
        decimal DiscountAmount,
        decimal ShippingCharge,
        string? CustomerNote,
        List<CreateOrderItemDto> Items
    ) : IRequest<CreateOrderResponseDto>;
}
