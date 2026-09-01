using EasyReach_Domain.Entities.Navigations;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// NavigationMenuItem er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;NavigationMenuItem&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// NavigationMenuItem er jonno kono extra/custom query (e.g. GetActiveNavigationMenuItemsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface INavigationMenuItemRepository : IGenericRepository<NavigationMenuItem>
    {
    }
}
