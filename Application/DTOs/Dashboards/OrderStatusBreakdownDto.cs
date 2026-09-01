using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Dashboards
{
    /// <summary>
    /// Dashboard er pie/donut chart e order status distribution
    /// dekhanor jonno - Order entity theke GroupBy(Status) kore.
    /// </summary>
    public class OrderStatusBreakdownDto
    {
        public OrderStatus Status { get; set; }
        public int Count { get; set; }
    }
}
