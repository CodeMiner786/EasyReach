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

namespace EasyReach_Application.CQRS.Querys.AdminIdentity
{
    public class GetAllRolesQueryHandler(IRoleRepository roleRepository, IMapper mapper)
        : IRequestHandler<GetAllRolesQuery, List<RoleDto>>
    {
        public async Task<List<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await roleRepository.GetAllAsync();
            return mapper.Map<List<RoleDto>>(roles);
        }
    }
}
