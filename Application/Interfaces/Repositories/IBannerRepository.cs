using EasyReach_Domain.Entities.CMSs;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// Banner er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;Banner&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// Banner er jonno kono extra/custom query (e.g. GetActiveBannersAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IBannerRepository : IGenericRepository<Banner>
    {
    }
}
