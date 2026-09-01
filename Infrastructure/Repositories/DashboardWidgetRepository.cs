using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Dashboards;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class DashboardWidgetRepository(ApplicationDbContext context) : GenericRepository<DashboardWidget>(context), IDashboardWidgetRepository
    {
    }
}



// IDashboardWidgetRepository er implementation. GenericRepository&lt;DashboardWidget&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e DashboardWidget-specific custom method thakle shegulo likha hobe.

