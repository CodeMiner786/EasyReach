using System;
using EasyReach_Domain.Common;
using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Domain.Entities.Orders
{
    // Order place korar shomoy product er naam/price snapshot rakha hoy,
    // jate porborti te product update hole purono order er data na change hoy.

    public class OrderItem : AuditableEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; } = null!;

        public string ProductNameSnapshot { get; set; } = string.Empty;
        public string VariantNameSnapshot { get; set; } = string.Empty;

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
