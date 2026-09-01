using EasyReach_Domain.Entities.Dashboards;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// DashboardWidget er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;DashboardWidget&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// DashboardWidget er jonno kono extra/custom query (e.g. GetActiveDashboardWidgetsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IDashboardWidgetRepository : IGenericRepository<DashboardWidget>
    {
    }
}
