using EasyReach_Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.Orders
{
    public record UpdateOrderStatusCommand(
        Guid OrderId,
        OrderStatus Status,
        PaymentStatus? PaymentStatus,
        Guid ProcessedByUserId,
        string? Note) : IRequest<bool>;
}
