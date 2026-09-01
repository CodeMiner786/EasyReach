using EasyReach_Domain.Entities.CMSs;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// FaqItem er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;FaqItem&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// FaqItem er jonno kono extra/custom query (e.g. GetActiveFaqItemsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IFaqItemRepository : IGenericRepository<FaqItem>
    {
    }
}
