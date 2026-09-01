using EasyReach_Domain.Common;
using EasyReach_Domain.Enums;

namespace EasyReach_Domain.Entities.Identities
{
    // Ekta atomic permission - ex: "Product.Create", "Order.UpdateStatus", "Manager.Create".
    // Module diye group kora, ar CRUD flags diye granular control.
    public class Permission : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;      // e.g. "Product.Create"
        public ModuleType Module { get; set; }
        public string? Description { get; set; }

        public bool CanView { get; set; }
        public bool CanCreate { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; } = [];
    }
}
