using EasyReach_Domain.Common;

namespace EasyReach_Domain.Entities.Identities
{
    // Ex: "Product Manager", "Order Manager", "Content Manager", "Super Admin".
    // Prottek Role er sathe kichu Permission attach thake (RolePermission).
    public class Role : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // System-defined role (SuperAdmin) delete kora jabe na
        public bool IsSystemRole { get; set; } = false;

        public ICollection<ApplicationUser> Users { get; set; } = [];
        public ICollection<RolePermission> RolePermissions { get; set; } = [];
    }
}
