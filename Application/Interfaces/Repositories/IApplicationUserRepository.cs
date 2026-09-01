using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// ApplicationUser er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;ApplicationUser&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// ApplicationUser er jonno kono extra/custom query (e.g. GetActiveApplicationUsersAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IApplicationUserRepository : IGenericRepository<ApplicationUser>
    {
        Task<ApplicationUser?> GetByEmailAsync(string email);
        Task<bool> IsEmailUniqueAsync(string email);
        Task<ApplicationUser?> GetUserWithRoleAndPermissionsAsync(Guid userId);
    }
}
