using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Promotions;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{

    public class DiscountRepository(ApplicationDbContext context) : GenericRepository<Discount>(context), IDiscountRepository
    {
    }
}


// IDiscountRepository er implementation. GenericRepository&lt;Discount&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e Discount-specific custom method thakle shegulo likha hobe.

