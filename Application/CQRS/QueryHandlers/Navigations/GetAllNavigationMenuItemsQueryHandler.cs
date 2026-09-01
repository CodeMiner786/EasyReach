using AutoMapper;
using EasyReach_Application.CQRS.Querys.Navigations;
using EasyReach_Application.DTOs.Navigations;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Common.Paginations;
using MediatR;

namespace EasyReach_Application.CQRS.QueryHandlers.Navigations
{
    public class GetAllNavigationMenuItemsQueryHandler(
        INavigationMenuItemRepository repository,
        IMapper mapper)
        : IRequestHandler<GetAllNavigationMenuItemsQuery, PagedResult<NavigationMenuItemDto>>
    {
        public async Task<PagedResult<NavigationMenuItemDto>> Handle(GetAllNavigationMenuItemsQuery request, CancellationToken cancellationToken)
        {
            var pagedItems = await repository.GetPagedAsync(
                request.PaginationParams,
                orderBy: q => q.OrderBy(x => x.DisplayOrder)
            );

            var mappedItems = mapper.Map<List<NavigationMenuItemDto>>(pagedItems.Items);

            return new PagedResult<NavigationMenuItemDto>(
                mappedItems,
                pagedItems.TotalCount,
                pagedItems.PageNumber,
                pagedItems.PageSize
            );
        }
    }

    public class GetNavigationTreeQueryHandler(
        INavigationMenuItemRepository repository,
        IMapper mapper)
        : IRequestHandler<GetNavigationTreeQuery, List<NavigationMenuItemDto>>
    {
        public async Task<List<NavigationMenuItemDto>> Handle(GetNavigationTreeQuery request, CancellationToken cancellationToken)
        {
            var allItems = await repository.GetAllAsync();
            var activeItems = allItems.Where(x => x.IsActive).OrderBy(x => x.DisplayOrder).ToList();
            var dtos = mapper.Map<List<NavigationMenuItemDto>>(activeItems);

            // Dynamic N-level Tree Nesting Build
            var dtoLookup = dtos.ToDictionary(x => x.Id);
            var rootNodes = new List<NavigationMenuItemDto>();

            foreach (var item in dtos)
            {
                if (item.ParentMenuItemId.HasValue && dtoLookup.TryGetValue(item.ParentMenuItemId.Value, out var parent))
                {
                    parent.Children.Add(item);
                }
                else
                {
                    rootNodes.Add(item);
                }
            }

            return rootNodes;
        }
    }

    public class GetNavigationMenuItemByIdQueryHandler(
        INavigationMenuItemRepository repository,
        IMapper mapper)
        : IRequestHandler<GetNavigationMenuItemByIdQuery, NavigationMenuItemDto?>
    {
        public async Task<NavigationMenuItemDto?> Handle(GetNavigationMenuItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await repository.GetByIdAsync(request.Id);
            return item == null ? null : mapper.Map<NavigationMenuItemDto>(item);
        }
    }
}

