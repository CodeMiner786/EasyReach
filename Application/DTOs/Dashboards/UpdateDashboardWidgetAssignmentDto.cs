using System;

namespace EasyReach_Application.DTOs.Dashboards
{
    /// <summary>
    /// Existing DashboardWidgetAssignment update korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class UpdateDashboardWidgetAssignmentDto
    {
        public Guid Id { get; set; }

        public Guid DashboardWidgetId { get; set; }

        public Guid RoleId { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsVisible { get; set; }
    }
}
