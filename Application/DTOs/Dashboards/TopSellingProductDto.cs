using System;

namespace EasyReach_Application.DTOs.Dashboards
{
    /// <summary>
    /// OrderItem entity theke Product ar ProductVariant er shathe join kore,
    /// shobcheye beshi bikri howa product gulo dekhanor jonno.
    /// </summary>
    public class TopSellingProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
