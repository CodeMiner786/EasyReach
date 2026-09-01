using EasyReach_Domain.Entities.Orders;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// ShippingAddress er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;ShippingAddress&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// ShippingAddress er jonno kono extra/custom query (e.g. GetActiveShippingAddresssAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IShippingAddressRepository : IGenericRepository<ShippingAddress>
    {
    }
}
