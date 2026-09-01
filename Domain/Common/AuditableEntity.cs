using System;

namespace EasyReach_Domain.Common
{
    /// <summary>
    /// Audit tracking (Create/Update/Delete history) lagbe emon entity gulo
    /// ei class theke inherit korbe. Soft delete o ekhane support kora hoyeche.
    /// </summary>
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? CreatedByUserId { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedByUserId { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public Guid? DeletedByUserId { get; set; }
    }
}
