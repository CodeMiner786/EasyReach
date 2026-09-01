using EasyReach_Domain.Entities.Notifications;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// Notification er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;Notification&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// Notification er jonno kono extra/custom query (e.g. GetActiveNotificationsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface INotificationRepository : IGenericRepository<Notification>
    {
    }
}
