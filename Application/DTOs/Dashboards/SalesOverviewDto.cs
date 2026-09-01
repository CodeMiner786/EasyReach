using System;

namespace EasyReach_Application.DTOs.Dashboards
{
    /// <summary>
    /// Dashboard er line/bar chart e day-wise sales dekhanor jonno.
    /// Order entity theke GroupBy(Date) kore banano hoy.
    /// </summary>
    public class SalesOverviewDto
    {
        public DateTime Date { get; set; }
        public decimal TotalSales { get; set; }
        public int OrderCount { get; set; }
    }
}
