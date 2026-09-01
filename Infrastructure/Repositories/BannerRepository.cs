using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.CMSs;
using EasyReach_Infrastructure.Persistence;
using EasyReach_Application.Interfaces;

namespace EasyReach_Infrastructure.Repositories
{
    // IBannerRepository er implementation. GenericRepository&lt;Banner&gt;
    // theke shob CRUD method already paay - ekhane shudhu constructor,
    // ar bhobishyot e Banner-specific custom method thakle shegulo likha hobe.

    public class BannerRepository(ApplicationDbContext context) : GenericRepository<Banner>(context), IBannerRepository
    {
    }
}
