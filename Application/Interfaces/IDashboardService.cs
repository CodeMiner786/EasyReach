using System.Collections.Generic;
using System.Threading.Tasks;
using EasyReach_Application.DTOs.Dashboards;

namespace EasyReach_Application.Interfaces
{
    /// <summary>
    /// Admin dashboard er shob data ei service theke ashbe.
    /// Implementation (DashboardService) Infrastructure/Application layer e
    /// giye Domain entity (Order, Product, ApplicationUser, AdminActivityLog)
    /// query kore ei DTO gulo populate korbe - kono notun entity/table lagbe na.
    /// </summary>
    public interface IDashboardService
    {
        Task<DashboardSummaryDto> GetSummaryAsync();

        Task<List<SalesOverviewDto>> GetSalesOverviewAsync(int lastNDays = 7);

        Task<List<TopSellingProductDto>> GetTopSellingProductsAsync(int count = 5);

        Task<List<RecentOrderDto>> GetRecentOrdersAsync(int count = 10);

        Task<List<LowStockProductDto>> GetLowStockProductsAsync(int threshold = 10);

        Task<List<OrderStatusBreakdownDto>> GetOrderStatusBreakdownAsync();

        Task<List<RecentActivityDto>> GetRecentActivitiesAsync(int count = 10);
    }
}
