using EasyReach_Domain.Entities.Orders;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// Order er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;Order&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// Order er jonno kono extra/custom query (e.g. GetActiveOrdersAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order?> GetOrderWithDetailsAsync(Guid orderId);
        Task<List<Order>> GetUserOrdersWithDetailsAsync(Guid userId);
        Task<bool> HasOrderInLast24HoursAsync(Guid userId, string phoneNumber);
    }
}
