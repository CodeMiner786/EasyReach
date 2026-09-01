using EasyReach_Domain.Entities.Carts;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// Cart er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;Cart&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// Cart er jonno kono extra/custom query (e.g. GetActiveCartsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface ICartRepository : IGenericRepository<Cart>
    {
    }
}
