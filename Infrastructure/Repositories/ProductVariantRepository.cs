using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Catalogs;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class ProductVariantRepository(ApplicationDbContext context) : GenericRepository<ProductVariant>(context), IProductVariantRepository
    {
    }
}


// IProductVariantRepository er implementation. GenericRepository&lt;ProductVariant&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e ProductVariant-specific custom method thakle shegulo likha hobe.

