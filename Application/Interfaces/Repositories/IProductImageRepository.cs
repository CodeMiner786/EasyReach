using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// ProductImage er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;ProductImage&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// ProductImage er jonno kono extra/custom query (e.g. GetActiveProductImagesAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IProductImageRepository : IGenericRepository<ProductImage>
    {
    }
}
