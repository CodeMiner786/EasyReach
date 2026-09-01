using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// RolePermission er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;RolePermission&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// RolePermission er jonno kono extra/custom query (e.g. GetActiveRolePermissionsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IRolePermissionRepository : IGenericRepository<RolePermission>
    {
    }
}
