using System;

namespace EasyReach_Application.DTOs.Dashboards
{
    /// <summary>
    /// Notun DashboardWidgetAssignment create korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class CreateDashboardWidgetAssignmentDto
    {
        public Guid DashboardWidgetId { get; set; }

        public Guid RoleId { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsVisible { get; set; }
    }
}
