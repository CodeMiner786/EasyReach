using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Catalogs;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class ProductImageRepository(ApplicationDbContext context) : GenericRepository<ProductImage>(context), IProductImageRepository
    {
    }
}




// IProductImageRepository er implementation. GenericRepository&lt;ProductImage&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e ProductImage-specific custom method thakle shegulo likha hobe.

