using AutoMapper;
using EasyReach_Application.CQRS.Commands.AdminIdentity;
using EasyReach_Application.DTOs.Identities;
using EasyReach_Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.AdminIdentity
{
    public class UpdateRoleCommandHandler(IRoleRepository roleRepository, IMapper mapper)
        : IRequestHandler<UpdateRoleCommand, RoleDto>
    {
        public async Task<RoleDto> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await roleRepository.GetByIdAsync(request.Dto.Id)
                ?? throw new KeyNotFoundException("Role not found.");

            mapper.Map(request.Dto, role);
            roleRepository.Update(role);
            await roleRepository.SaveChangesAsync();

            return mapper.Map<RoleDto>(role);
        }
    }
}
