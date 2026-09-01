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
    public class GetAllPermissionsQueryHandler(IPermissionRepository permissionRepository, IMapper mapper)
        : IRequestHandler<GetAllPermissionsQuery, List<PermissionDto>>
    {
        public async Task<List<PermissionDto>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
        {
            var permissions = await permissionRepository.GetAllAsync();
            return mapper.Map<List<PermissionDto>>(permissions);
        }
    }
}
