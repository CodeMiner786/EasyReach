using AutoMapper;
using EasyReach_Application.CQRS.Commands.Navigations;
using EasyReach_Application.DTOs.Navigations;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Navigations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
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

            // ১. Empty Guid গুলোকে null করে দেওয়া (Foreign Key Violation আটকানোর জন্য)
            if (entity.ParentMenuItemId == Guid.Empty) entity.ParentMenuItemId = null;
            if (entity.RequiredPermissionId == Guid.Empty) entity.RequiredPermissionId = null;

            // ২. Primary Key, Timestamp এবং লগইন করা Admin-এর UserId সেট করা
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedByUserId = request.UserId; // 👈 টোকেন থেকে আসা Admin User ID

            entity.ChildMenuItems ??= [];

            // ৩. ডাটাবেজে সেভ
            await repository.AddAsync(entity);
            await repository.SaveChangesAsync();

            return mapper.Map<NavigationMenuItemDto>(entity);
        }
    }
}

