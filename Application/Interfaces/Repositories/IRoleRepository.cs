using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// Role er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;Role&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// Role er jonno kono extra/custom query (e.g. GetActiveRolesAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IRoleRepository : IGenericRepository<Role>
    {
    }
}
