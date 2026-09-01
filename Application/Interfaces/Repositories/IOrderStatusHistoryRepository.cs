using EasyReach_Domain.Entities.Orders;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// OrderStatusHistory er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;OrderStatusHistory&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// OrderStatusHistory er jonno kono extra/custom query (e.g. GetActiveOrderStatusHistorysAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IOrderStatusHistoryRepository : IGenericRepository<OrderStatusHistory>
    {
    }
}
