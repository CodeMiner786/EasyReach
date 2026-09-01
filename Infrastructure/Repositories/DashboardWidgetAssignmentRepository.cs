using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Dashboards;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class DashboardWidgetAssignmentRepository(ApplicationDbContext context) : GenericRepository<DashboardWidgetAssignment>(context), IDashboardWidgetAssignmentRepository
    {
    }
}


// IDashboardWidgetAssignmentRepository er implementation. GenericRepository&lt;DashboardWidgetAssignment&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e DashboardWidgetAssignment-specific custom method thakle shegulo likha hobe.

