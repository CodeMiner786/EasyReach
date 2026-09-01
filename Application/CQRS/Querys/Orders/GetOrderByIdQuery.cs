using EasyReach_Application.DTOs.Orders;
using EasyReach_Domain.Common.Paginations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Querys.Orders
{
    public record GetOrderByIdQuery(Guid OrderId) : IRequest<OrderDto?>;
    public class GetUserOrdersQuery : IRequest<PagedResult<OrderHistoryDto>>
    {
        public Guid UserId { get; set; }
        public PaginationParams PaginationParams { get; set; } = new();
    }
}
