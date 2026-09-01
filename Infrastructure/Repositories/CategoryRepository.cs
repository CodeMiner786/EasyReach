using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Catalogs;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class CategoryRepository(ApplicationDbContext context) : GenericRepository<Category>(context), ICategoryRepository
    {
    }
}


// ICategoryRepository er implementation. GenericRepository&lt;Category&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e Category-specific custom method thakle shegulo likha hobe.
