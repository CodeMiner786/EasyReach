namespace EasyReach_Application.DTOs.Dashboards
{
    /// <summary>
    /// Dashboard er top card gulor jonno - Product, Order, ApplicationUser
    /// entity theke aggregate (COUNT/SUM) kore ei DTO fill kora hoy.
    /// Kono table e ei data store hoy na - shob shomoy live query result.
    /// </summary>
    public class DashboardSummaryDto
    {
        public int TotalOrders { get; set; }
        public int PendingOrders { get; set; }
        public int TodayOrders { get; set; }

        public decimal TotalRevenue { get; set; }
        public decimal TodayRevenue { get; set; }

        public int TotalCustomers { get; set; }
        public int TotalProducts { get; set; }
        public int LowStockProductCount { get; set; }
        public int OutOfStockProductCount { get; set; }
    }
}
