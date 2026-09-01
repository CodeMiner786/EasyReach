using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Orders
{
    /// <summary>
    /// Order - system/business-logic theke generate hoy (Order placement, Cart operation etc.), tai shudhu Response DTO - kono Create/Update admin form nei.
    /// </summary>
    public class OrderDto
    {
        public Guid Id { get; set; }

        public string OrderNumber { get; set; } = string.Empty;

        public Guid UserId { get; set; }

        public Guid ShippingAddressId { get; set; }

        public OrderStatus Status { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public decimal SubTotal { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal ShippingCharge { get; set; }

        public decimal GrandTotal { get; set; }

        public DateTime PlacedAt { get; set; }

        public string? CustomerNote { get; set; }

        public Guid? ProcessedByUserId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
