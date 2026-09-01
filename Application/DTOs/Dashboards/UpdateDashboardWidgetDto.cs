using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Dashboards
{
    /// <summary>
    /// Existing DashboardWidget update korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class UpdateDashboardWidgetDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public DashboardWidgetType WidgetType { get; set; }

        public string DataSourceKey { get; set; } = string.Empty;

        public string? IconClass { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }
    }
}
