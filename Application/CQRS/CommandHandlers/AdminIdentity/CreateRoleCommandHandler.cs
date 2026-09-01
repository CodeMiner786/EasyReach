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
    public class CreateRoleCommandHandler(IRoleRepository roleRepository, IMapper mapper)
        : IRequestHandler<CreateRoleCommand, RoleDto>
    {
        public async Task<RoleDto> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = mapper.Map<Role>(request.Dto);
            await roleRepository.AddAsync(role);
            await roleRepository.SaveChangesAsync();
            return mapper.Map<RoleDto>(role);
        }
    }
}
