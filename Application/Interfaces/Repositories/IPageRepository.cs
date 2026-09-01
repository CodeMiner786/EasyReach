using EasyReach_Domain.Entities.CMSs;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// Page er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;Page&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// Page er jonno kono extra/custom query (e.g. GetActivePagesAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IPageRepository : IGenericRepository<Page>
    {
    }
}
