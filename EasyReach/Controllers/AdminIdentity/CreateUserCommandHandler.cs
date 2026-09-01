using AutoMapper;
using EasyReach_Application.CQRS.Commands.AdminIdentity;
using EasyReach_Application.DTOs.Identities;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Identities;
using MediatR;

namespace EasyReach.Controllers.AdminIdentity
{
    // --- USER HANDLERS ---
    public class CreateUserCommandHandler(IApplicationUserRepository userRepository, IMapper mapper)
        : IRequestHandler<CreateUserCommand, ApplicationUserDto>
    {
        public async Task<ApplicationUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<ApplicationUser>(request.Dto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Dto.Password);

            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();
            return mapper.Map<ApplicationUserDto>(user);
        }
    }

    public class GetAllUsersQueryHandler(IApplicationUserRepository userRepository, IMapper mapper)
        : IRequestHandler<GetAllUsersQuery, List<ApplicationUserDto>>
    {
        public async Task<List<ApplicationUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetAllAsync();
            return mapper.Map<List<ApplicationUserDto>>(users);
        }
    }

    // --- ROLE HANDLERS ---
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

    public class AssignPermissionsToRoleCommandHandler(
        IRolePermissionRepository rolePermissionRepository)
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

    // --- PERMISSION HANDLERS ---
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
