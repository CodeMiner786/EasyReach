using EasyReach_Application.DTOs.Navigations;
using EasyReach_Domain.Common.Paginations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Querys.Navigations
{
    public class GetAllNavigationMenuItemsQuery : IRequest<PagedResult<NavigationMenuItemDto>>
    {
        public PaginationParams PaginationParams { get; set; } = new();
    }

    public record GetNavigationTreeQuery() : IRequest<List<NavigationMenuItemDto>>;
    public record GetNavigationMenuItemByIdQuery(Guid Id) : IRequest<NavigationMenuItemDto?>;
}
