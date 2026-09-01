using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Wishlists;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class WishlistItemRepository(ApplicationDbContext context) : GenericRepository<WishlistItem>(context), IWishlistItemRepository
    {
    }
}



// IWishlistItemRepository er implementation. GenericRepository&lt;WishlistItem&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e WishlistItem-specific custom method thakle shegulo likha hobe.

