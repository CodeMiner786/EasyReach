using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// AdminActivityLog er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;AdminActivityLog&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// AdminActivityLog er jonno kono extra/custom query (e.g. GetActiveAdminActivityLogsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IAdminActivityLogRepository : IGenericRepository<AdminActivityLog>
    {
    }
}
