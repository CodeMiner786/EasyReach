using EasyReach_Application.DTOs.Navigations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.Navigations
{
    public record CreateNavigationMenuItemCommand(
        CreateNavigationMenuItemDto Dto,
        Guid UserId
    ) : IRequest<NavigationMenuItemDto>;
    public record UpdateNavigationMenuItemCommand(UpdateNavigationMenuItemDto Dto) : IRequest<NavigationMenuItemDto>;
    public record DeleteNavigationMenuItemCommand(Guid Id) : IRequest<bool>;
}
