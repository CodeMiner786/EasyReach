using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Identities
{
    /// <summary>
    /// AdminActivityLog - system/business-logic theke generate hoy (Order placement, Cart operation etc.), tai shudhu Response DTO - kono Create/Update admin form nei.
    /// </summary>
    public class AdminActivityLogDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public ActivityActionType ActionType { get; set; }

        public ModuleType Module { get; set; }

        public string? Description { get; set; }

        public string? AffectedEntityId { get; set; }

        public string? IpAddress { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
