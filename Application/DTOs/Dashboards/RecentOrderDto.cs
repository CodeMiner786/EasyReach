using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Dashboards
{
    /// <summary>
    /// Dashboard er "Recent Orders" table er jonno - Order + ApplicationUser
    /// theke shudhu dorkari field gulo niye ei flat shape banano hoy.
    /// </summary>
    public class RecentOrderDto
    {
        public Guid OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public OrderStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal GrandTotal { get; set; }
        public DateTime PlacedAt { get; set; }
    }
}
