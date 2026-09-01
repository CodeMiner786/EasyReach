using EasyReach_Domain.Entities.Dashboards;

namespace EasyReach_Application.Interfaces.Repositories
{
    /// <summary>
    /// DashboardWidgetAssignment er jonno specific repository contract. Ekhon shudhu
    /// IGenericRepository&lt;DashboardWidgetAssignment&gt; er common CRUD (GetByIdAsync, GetAllAsync,
    /// FindAsync, AddAsync, Update, Remove, SaveChangesAsync) inherit kora hoyeche.
    /// DashboardWidgetAssignment er jonno kono extra/custom query (e.g. GetActiveDashboardWidgetAssignmentsAsync)
    /// lagle eikhane notun method signature add korte hobe - baki shob CRUD
    /// automatic pabe, notun kore likhte hobe na.
    /// </summary>
    public interface IDashboardWidgetAssignmentRepository : IGenericRepository<DashboardWidgetAssignment>
    {
    }
}
