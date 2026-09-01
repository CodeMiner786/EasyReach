using EasyReach_Application.DTOs.Identities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.AdminIdentity
{
    // User Management Commands & Queries
    public record CreateUserCommand(CreateApplicationUserDto Dto) : IRequest<ApplicationUserDto>;
    public record UpdateUserCommand(UpdateApplicationUserDto Dto) : IRequest<ApplicationUserDto>;
    public record DeleteUserCommand(Guid Id) : IRequest<bool>;
    public record GetAllUsersQuery() : IRequest<List<ApplicationUserDto>>;
    public record GetUserByIdQuery(Guid Id) : IRequest<ApplicationUserDto?>;

    // Role Management Commands & Queries
    public record CreateRoleCommand(CreateRoleDto Dto) : IRequest<RoleDto>;
    public record UpdateRoleCommand(UpdateRoleDto Dto) : IRequest<RoleDto>;
    public record DeleteRoleCommand(Guid Id) : IRequest<bool>;
    public record GetAllRolesQuery() : IRequest<List<RoleDto>>;
    public record AssignPermissionsToRoleCommand(AssignRolePermissionsDto Dto) : IRequest<bool>;

    // Permission Management Commands & Queries
    public record CreatePermissionCommand(CreatePermissionDto Dto) : IRequest<PermissionDto>;
    public record GetAllPermissionsQuery() : IRequest<List<PermissionDto>>;
}
