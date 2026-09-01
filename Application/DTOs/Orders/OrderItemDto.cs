using System;

namespace EasyReach_Application.DTOs.Orders
{
    /// <summary>
    /// OrderItem - system/business-logic theke generate hoy (Order placement, Cart operation etc.), tai shudhu Response DTO - kono Create/Update admin form nei.
    /// </summary>
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductVariantId { get; set; }
        public string ProductNameSnapshot { get; set; } = string.Empty;
        public string VariantNameSnapshot { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
