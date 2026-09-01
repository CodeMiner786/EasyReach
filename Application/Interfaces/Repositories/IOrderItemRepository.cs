using EasyReach_Domain.Entities.Orders;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// OrderItem er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;OrderItem&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// OrderItem er jonno kono extra/custom query (e.g. GetActiveOrderItemsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
    }
}
