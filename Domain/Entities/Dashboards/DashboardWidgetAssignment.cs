using System;
using EasyReach_Domain.Common;
using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Domain.Entities.Dashboards
{
    /// <summary>
    /// Kon Role (Manager/Admin type) dashboard e kon widget dekhbe ar
    /// kon order e dekhbe - eta SuperAdmin e assign kore.
    /// Ei junction table na thakle shobar dashboard e shob widget dekha jeto,
    /// customization er dorkar hoto na.
    /// </summary>
    public class DashboardWidgetAssignment : AuditableEntity
    {
        public Guid DashboardWidgetId { get; set; }
        public DashboardWidget DashboardWidget { get; set; } = null!;

        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public int DisplayOrder { get; set; }
        public bool IsVisible { get; set; } = true;
    }
}
