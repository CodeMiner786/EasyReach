namespace EasyReach_Domain.Enums
{
    /// <summary>
    /// Dashboard e widget ta UI te kon shape e render hobe seta define kore.
    /// </summary>
    public enum DashboardWidgetType
    {
        SummaryCard = 1,   // e.g. Total Orders, Total Revenue
        LineChart = 2,     // e.g. Sales Overview
        BarChart = 3,
        PieChart = 4,      // e.g. Order Status Breakdown
        DataTable = 5,     // e.g. Recent Orders, Low Stock
        ActivityFeed = 6   // e.g. Recent Activity
    }
}
