using EasyReach_Domain.Common;
using EasyReach_Domain.Entities.Identities;
using EasyReach_Domain.Enums;

namespace EasyReach_Domain.Entities.Orders
{
    public class Order : AuditableEntity
    {
        public string OrderNumber { get; set; } = string.Empty;

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public Guid ShippingAddressId { get; set; }
        public ShippingAddress ShippingAddress { get; set; } = null!;

        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
        public PaymentMethod PaymentMethod { get; set; }

        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal ShippingCharge { get; set; }
        public decimal GrandTotal { get; set; }

        // SslCommerzService validation error দূর করার জন্য alias property
        public decimal TotalAmount => GrandTotal;

        public DateTime PlacedAt { get; set; } = DateTime.UtcNow;
        public string? CustomerNote { get; set; }

        // Kon manager order ta process/update korlo
        public Guid? ProcessedByUserId { get; set; }

        public ICollection<OrderItem> Items { get; set; } = [];
        public ICollection<OrderStatusHistory> StatusHistory { get; set; } = [];
    }
}
