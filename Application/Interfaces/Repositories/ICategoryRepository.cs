using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// Category er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;Category&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// Category er jonno kono extra/custom query (e.g. GetActiveCategorysAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
