using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// Permission er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;Permission&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// Permission er jonno kono extra/custom query (e.g. GetActivePermissionsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IPermissionRepository : IGenericRepository<Permission>
    {
    }
}
