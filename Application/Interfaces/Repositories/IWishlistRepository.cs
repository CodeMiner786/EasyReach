using EasyReach_Domain.Entities.Wishlists;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// Wishlist er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;Wishlist&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// Wishlist er jonno kono extra/custom query (e.g. GetActiveWishlistsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IWishlistRepository : IGenericRepository<Wishlist>
    {
    }
}
