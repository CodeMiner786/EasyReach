using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Wishlists;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class WishlistRepository(ApplicationDbContext context) : GenericRepository<Wishlist>(context), IWishlistRepository
    {
    }
}


// IWishlistRepository er implementation. GenericRepository&lt;Wishlist&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e Wishlist-specific custom method thakle shegulo likha hobe.

