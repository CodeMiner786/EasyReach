using EasyReach_Domain.Entities.Promotions;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// Combo er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;Combo&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// Combo er jonno kono extra/custom query (e.g. GetActiveCombosAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IComboRepository : IGenericRepository<Combo>
    {
    }
}
