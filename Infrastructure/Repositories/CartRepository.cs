using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Carts;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class CartRepository(ApplicationDbContext context) : GenericRepository<Cart>(context), ICartRepository
    {
    }
}


// ICartRepository er implementation. GenericRepository&lt;Cart&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e Cart-specific custom method thakle shegulo likha hobe.