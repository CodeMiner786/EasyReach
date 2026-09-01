using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Identities;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class RoleRepository(ApplicationDbContext context) : GenericRepository<Role>(context), IRoleRepository
    {
    }
}


// IRoleRepository er implementation. GenericRepository&lt;Role&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e Role-specific custom method thakle shegulo likha hobe.

