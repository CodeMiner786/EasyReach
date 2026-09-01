using System;
using System.Collections.Generic;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Orders
{
    /// <summary>
    /// "My Orders" page er jonno - Order, Payment, OrderItem theke
    /// property niye banano. Kono notun table lage na.
    /// </summary>
    public class OrderHistoryDto
    {
        public Guid OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;

        public OrderStatus OrderStatus { get; set; }        // Order.Status
        public PaymentStatus PaymentStatus { get; set; }    // Order.PaymentStatus / Payment.Status
        public PaymentMethod PaymentMethod { get; set; }    // Order.PaymentMethod

        public decimal GrandTotal { get; set; }             // Order.GrandTotal
        public DateTime PlacedAt { get; set; }               // Order.PlacedAt
        public DateTime? PaidAt { get; set; }                // Payment.PaidAt

        public List<OrderHistoryItemDto> Items { get; set; } = [];
    }
}
