using EasyReach_Domain.Entities.Promotions;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// ComboItem er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;ComboItem&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// ComboItem er jonno kono extra/custom query (e.g. GetActiveComboItemsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IComboItemRepository : IGenericRepository<ComboItem>
    {
    }
}
