using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.CMSs;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    // IFaqItemRepository er implementation. GenericRepository&lt;FaqItem&gt;
    // theke shob CRUD method already paay - ekhane shudhu constructor,
    // ar bhobishyot e FaqItem-specific custom method thakle shegulo likha hobe.
    public class FaqItemRepository(ApplicationDbContext context) : GenericRepository<FaqItem>(context), IFaqItemRepository
    {
    }
}
