using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Identities;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class PermissionRepository(ApplicationDbContext context) : GenericRepository<Permission>(context), IPermissionRepository
    {
    }
}


// IPermissionRepository er implementation. GenericRepository&lt;Permission&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e Permission-specific custom method thakle shegulo likha hobe.

