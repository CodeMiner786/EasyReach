using System;

namespace EasyReach_Application.DTOs.Identities
{
    /// <summary>
    /// RolePermission - system/business-logic theke generate hoy (Order placement, Cart operation etc.), tai shudhu Response DTO - kono Create/Update admin form nei.
    /// </summary>
    public class RolePermissionDto
    {
        public Guid Id { get; set; }

        public Guid RoleId { get; set; }

        public Guid PermissionId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
