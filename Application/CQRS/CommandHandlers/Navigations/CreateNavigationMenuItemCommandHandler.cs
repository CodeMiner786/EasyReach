using AutoMapper;
using EasyReach_Application.CQRS.Commands.Navigations;
using EasyReach_Application.DTOs.Navigations;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Navigations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.Navigations
{
    public class CreateNavigationMenuItemCommandHandler(
        INavigationMenuItemRepository repository,
        IMapper mapper)
        : IRequestHandler<CreateNavigationMenuItemCommand, NavigationMenuItemDto>
    {
        public async Task<NavigationMenuItemDto> Handle(CreateNavigationMenuItemCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<NavigationMenuItem>(request.Dto);
            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();

            return mapper.Map<NavigationMenuItemDto>(entity);
        }
    }

    public class UpdateNavigationMenuItemCommandHandler(
        INavigationMenuItemRepository repository,
        IMapper mapper)
        : IRequestHandler<UpdateNavigationMenuItemCommand, NavigationMenuItemDto>
    {
        public async Task<NavigationMenuItemDto> Handle(UpdateNavigationMenuItemCommand request, CancellationToken cancellationToken)
        {
            var item = await repository.GetByIdAsync(request.Dto.Id)
                ?? throw new KeyNotFoundException("Navigation menu item not found.");

            mapper.Map(request.Dto, item);
            repository.Update(item);
            await repository.SaveChangesAsync();

            return mapper.Map<NavigationMenuItemDto>(item);
        }
    }

    public class DeleteNavigationMenuItemCommandHandler(INavigationMenuItemRepository repository)
        : IRequestHandler<DeleteNavigationMenuItemCommand, bool>
    {
        public async Task<bool> Handle(DeleteNavigationMenuItemCommand request, CancellationToken cancellationToken)
        {
            var item = await repository.GetByIdAsync(request.Id)
                ?? throw new KeyNotFoundException("Navigation menu item not found.");

            repository.Remove(item);
            await repository.SaveChangesAsync();
            return true;
        }
    }
}
