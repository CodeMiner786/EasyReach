using EasyReach_Application.CQRS.Commands.AdminIdentity;
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
    public class AssignPermissionsToRoleCommandHandler(IRolePermissionRepository rolePermissionRepository)
        : IRequestHandler<AssignPermissionsToRoleCommand, bool>
    {
        public async Task<bool> Handle(AssignPermissionsToRoleCommand request, CancellationToken cancellationToken)
        {
            var existingPermissions = await rolePermissionRepository.FindAsync(x => x.RoleId == request.Dto.RoleId);
            foreach (var item in existingPermissions)
            {
                rolePermissionRepository.Remove(item);
            }

            foreach (var permId in request.Dto.PermissionIds)
            {
                await rolePermissionRepository.AddAsync(new RolePermission
                {
                    RoleId = request.Dto.RoleId,
                    PermissionId = permId
                });
            }

            await rolePermissionRepository.SaveChangesAsync();
            return true;
        }
    }
}
