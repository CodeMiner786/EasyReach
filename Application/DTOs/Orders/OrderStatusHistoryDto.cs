using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Orders
{
    /// <summary>
    /// OrderStatusHistory - system/business-logic theke generate hoy (Order placement, Cart operation etc.), tai shudhu Response DTO - kono Create/Update admin form nei.
    /// </summary>
    public class OrderStatusHistoryDto
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public OrderStatus Status { get; set; }

        public string? Note { get; set; }

        public Guid? ChangedByUserId { get; set; }

        public DateTime ChangedAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
