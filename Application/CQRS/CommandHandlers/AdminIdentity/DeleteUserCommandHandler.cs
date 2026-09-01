using EasyReach_Application.CQRS.Commands.AdminIdentity;
using EasyReach_Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.AdminIdentity
{
    public class DeleteRoleCommandHandler(IRoleRepository roleRepository)
        : IRequestHandler<DeleteRoleCommand, bool>
    {
        public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await roleRepository.GetByIdAsync(request.Id)
                ?? throw new KeyNotFoundException("Role not found.");

            roleRepository.Remove(role);
            await roleRepository.SaveChangesAsync();
            return true;
        }
    }
}
