using System;

namespace EasyReach_Application.DTOs.Dashboards
{
    /// <summary>
    /// ProductVariant entity theke stock alert er jonno - manager ra
    /// dashboard e ekhane dekhbe kon variant re-stock korte hobe.
    /// </summary>
    public class LowStockProductDto
    {
        public Guid ProductId { get; set; }
        public Guid ProductVariantId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string VariantName { get; set; } = string.Empty;
        public int StockQuantity { get; set; }
    }
}
