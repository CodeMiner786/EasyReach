using EasyReach_Domain.Entities.Carts;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// CartItem er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;CartItem&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// CartItem er jonno kono extra/custom query (e.g. GetActiveCartItemsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
    }
}
