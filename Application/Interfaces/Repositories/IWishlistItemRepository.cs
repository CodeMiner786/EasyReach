using EasyReach_Domain.Entities.Wishlists;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// WishlistItem er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;WishlistItem&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// WishlistItem er jonno kono extra/custom query (e.g. GetActiveWishlistItemsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IWishlistItemRepository : IGenericRepository<WishlistItem>
    {
    }
}
