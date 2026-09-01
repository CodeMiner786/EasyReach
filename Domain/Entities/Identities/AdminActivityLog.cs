using System;
using EasyReach_Domain.Common;
using EasyReach_Domain.Enums;

namespace EasyReach_Domain.Entities.Identities
{
    // Admin/Manager panel e ke kokhon ki korlo - audit trail.
    // Accountability ar security er jonno guruttopurno.

    public class AdminActivityLog : AuditableEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public ActivityActionType ActionType { get; set; }
        public ModuleType Module { get; set; }
        public string? Description { get; set; }
        public string? AffectedEntityId { get; set; }
        public string? IpAddress { get; set; }
    }
}
