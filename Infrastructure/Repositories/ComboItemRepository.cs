using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Promotions;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class ComboItemRepository(ApplicationDbContext context) : GenericRepository<ComboItem>(context), IComboItemRepository
    {
    }
}


// IComboItemRepository er implementation. GenericRepository&lt;ComboItem&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e ComboItem-specific custom method thakle shegulo likha hobe.
