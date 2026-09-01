using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// Brand er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;Brand&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// Brand er jonno kono extra/custom query (e.g. GetActiveBrandsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IBrandRepository : IGenericRepository<Brand>
    {
    }
}
