using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Identities;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    // IAdminActivityLogRepository er implementation. GenericRepository&lt;AdminActivityLog&gt;
    // theke shob CRUD method already paay - ekhane shudhu constructor,
    // ar bhobishyot e AdminActivityLog-specific custom method thakle shegulo likha hobe.
    public class AdminActivityLogRepository(ApplicationDbContext context) : GenericRepository<AdminActivityLog>(context), IAdminActivityLogRepository
    {
    }
}
