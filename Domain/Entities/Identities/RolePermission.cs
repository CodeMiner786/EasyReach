using EasyReach_Domain.Common;

namespace EasyReach_Domain.Entities.Identities
{
    // Role <-> Permission er many-to-many junction table.
    // Ei table diyei "kon manager ki operation korte parbe" seta control hoy.
    public class RolePermission : AuditableEntity
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; } = null!;
    }
}
