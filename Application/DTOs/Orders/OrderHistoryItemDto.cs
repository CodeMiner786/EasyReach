using System;

namespace EasyReach_Application.DTOs.Orders
{
    /// <summary>
    /// OrderItem theke - product snapshot dekhanor jonno (order er shomoy
    /// jei naam/price chilo, product porjonto update hoyeo eta change hobe na).
    /// </summary>
    public class OrderHistoryItemDto
    {
        public string ProductNameSnapshot { get; set; } = string.Empty;
        public string VariantNameSnapshot { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
