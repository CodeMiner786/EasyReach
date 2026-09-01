using System;
using System.Collections.Generic;
using EasyReach_Domain.Common;
using EasyReach_Domain.Enums;

namespace EasyReach_Domain.Entities.Dashboards
{
    /// <summary>
    /// Dashboard e ekta widget/card er master definition (e.g. "Total Revenue",
    /// "Top Selling Products"). Shudhu SuperAdmin ei widget create/edit/delete
    /// korte parbe - eta enforce hobe Application layer er authorization
    /// policy diye (UserType.SuperAdmin check), entity level e kono restriction
    /// field rakha hoyni karon eta business rule, data na.
    ///
    /// DataSourceKey IDashboardService er kon method theke data anbe seta
    /// point kore (e.g. "SalesOverview", "TopSellingProducts").
    /// </summary>
    public class DashboardWidget : AuditableEntity
    {
        public string Title { get; set; } = string.Empty;
        public DashboardWidgetType WidgetType { get; set; }
        public string DataSourceKey { get; set; } = string.Empty;

        public string? IconClass { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;

        // Ei widget ta SuperAdmin toiri korlo (audit er jonno)

        public ICollection<DashboardWidgetAssignment> Assignments { get; set; } = [];
    }
}
