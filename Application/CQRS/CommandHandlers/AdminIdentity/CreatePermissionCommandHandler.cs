using AutoMapper;
using EasyReach_Application.CQRS.Commands.AdminIdentity;
using EasyReach_Application.DTOs.Identities;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Identities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.AdminIdentity
{
    public class CreatePermissionCommandHandler(IPermissionRepository permissionRepository, IMapper mapper)
        : IRequestHandler<CreatePermissionCommand, PermissionDto>
    {
        public async Task<PermissionDto> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = mapper.Map<Permission>(request.Dto);
            await permissionRepository.AddAsync(permission);
            await permissionRepository.SaveChangesAsync();

            return mapper.Map<PermissionDto>(permission);
        }
    }
}
