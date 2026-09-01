using EasyReach_Domain.Entities.Promotions;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// Discount er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;Discount&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// Discount er jonno kono extra/custom query (e.g. GetActiveDiscountsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IDiscountRepository : IGenericRepository<Discount>
    {
    }
}
