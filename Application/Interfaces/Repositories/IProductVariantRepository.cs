using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// ProductVariant er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;ProductVariant&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// ProductVariant er jonno kono extra/custom query (e.g. GetActiveProductVariantsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IProductVariantRepository : IGenericRepository<ProductVariant>
    {
    }
}
