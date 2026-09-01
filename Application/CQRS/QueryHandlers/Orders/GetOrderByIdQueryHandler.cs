using AutoMapper;
using EasyReach_Application.CQRS.Querys.Orders;
using EasyReach_Application.DTOs.Orders;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Common.Paginations;
using MediatR;

namespace EasyReach_Application.CQRS.QueryHandlers.Orders
{
    public class GetOrderByIdQueryHandler(
        IOrderRepository orderRepository,
        IMapper mapper) : IRequestHandler<GetOrderByIdQuery, OrderDto?>
    {
        public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await orderRepository.GetOrderWithDetailsAsync(request.OrderId);
            if (order is null) return null;

            return mapper.Map<OrderDto>(order);
        }
    }

    public class GetUserOrdersQueryHandler(
        IOrderRepository orderRepository,
        IMapper mapper) : IRequestHandler<GetUserOrdersQuery, PagedResult<OrderHistoryDto>>
    {
        public async Task<PagedResult<OrderHistoryDto>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
        {
            var pagedOrders = await orderRepository.GetPagedAsync(
                request.PaginationParams,
                predicate: o => o.UserId == request.UserId,
                orderBy: q => q.OrderByDescending(o => o.CreatedAt),
                includeProperties: "Items,Items.ProductVariant,Items.ProductVariant.Product"
            );

            var mappedItems = mapper.Map<List<OrderHistoryDto>>(pagedOrders.Items);

            return new PagedResult<OrderHistoryDto>(
                mappedItems,
                pagedOrders.TotalCount,
                pagedOrders.PageNumber,
                pagedOrders.PageSize
            );
        }
    }
}

