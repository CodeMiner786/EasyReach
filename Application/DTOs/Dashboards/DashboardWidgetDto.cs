using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Dashboards
{
    /// <summary>
    /// DashboardWidget entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class DashboardWidgetDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public DashboardWidgetType WidgetType { get; set; }

        public string DataSourceKey { get; set; } = string.Empty;

        public string? IconClass { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
