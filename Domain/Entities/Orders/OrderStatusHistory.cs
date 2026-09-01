using EasyReach_Domain.Common;
using EasyReach_Domain.Enums;

namespace EasyReach_Domain.Entities.Orders
{
    // Order Tracking page er jonno - status change er full timeline.

    public class OrderStatusHistory : AuditableEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public OrderStatus Status { get; set; }
        public string? Note { get; set; }

        public Guid? ChangedByUserId { get; set; }
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
    }
}
