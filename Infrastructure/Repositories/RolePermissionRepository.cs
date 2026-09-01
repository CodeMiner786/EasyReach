using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Identities;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class RolePermissionRepository(ApplicationDbContext context) : GenericRepository<RolePermission>(context), IRolePermissionRepository
    {
    }
}


// IRolePermissionRepository er implementation. GenericRepository&lt;RolePermission&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e RolePermission-specific custom method thakle shegulo likha hobe.

