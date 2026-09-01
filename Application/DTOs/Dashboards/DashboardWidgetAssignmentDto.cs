using System;

namespace EasyReach_Application.DTOs.Dashboards
{
    /// <summary>
    /// DashboardWidgetAssignment entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class DashboardWidgetAssignmentDto
    {
        public Guid Id { get; set; }

        public Guid DashboardWidgetId { get; set; }

        public Guid RoleId { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsVisible { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
