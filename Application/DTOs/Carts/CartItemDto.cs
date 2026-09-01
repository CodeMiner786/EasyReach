using System;

namespace EasyReach_Application.DTOs.Carts
{
    /// <summary>
    /// CartItem - system/business-logic theke generate hoy (Order placement, Cart operation etc.), tai shudhu Response DTO - kono Create/Update admin form nei.
    /// </summary>
    public class CartItemDto
    {
        public Guid Id { get; set; }

        public Guid CartId { get; set; }

        public Guid ProductVariantId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPriceSnapshot { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
