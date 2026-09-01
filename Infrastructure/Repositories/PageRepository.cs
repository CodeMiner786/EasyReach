using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.CMSs;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class PageRepository(ApplicationDbContext context) : GenericRepository<Page>(context), IPageRepository
    {
    }
}


// IPageRepository er implementation. GenericRepository&lt;Page&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e Page-specific custom method thakle shegulo likha hobe.

