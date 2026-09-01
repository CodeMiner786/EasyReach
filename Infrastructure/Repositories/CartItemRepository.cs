using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Carts;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    // ICartItemRepository er implementation. GenericRepository&lt;CartItem&gt;
    // theke shob CRUD method already paay - ekhane shudhu constructor,
    // ar bhobishyot e CartItem-specific custom method thakle shegulo likha hobe.
    public class CartItemRepository(ApplicationDbContext context) : GenericRepository<CartItem>(context), ICartItemRepository
    {
    }
}
