using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Catalogs;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    // IBrandRepository er implementation. GenericRepository&lt;Brand&gt;
    // theke shob CRUD method already paay - ekhane shudhu constructor,
    // ar bhobishyot e Brand-specific custom method thakle shegulo likha hobe.
    public class BrandRepository(ApplicationDbContext context) : GenericRepository<Brand>(context), IBrandRepository
    {
    }
}
