using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Catalogs;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class ProductRepository(ApplicationDbContext context) : GenericRepository<Product>(context), IProductRepository
    {
    }
}



// IProductRepository er implementation. GenericRepository&lt;Product&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e Product-specific custom method thakle shegulo likha hobe.

