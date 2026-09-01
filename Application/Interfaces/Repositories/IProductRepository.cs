using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// Product er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;Product&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// Product er jonno kono extra/custom query (e.g. GetActiveProductsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
