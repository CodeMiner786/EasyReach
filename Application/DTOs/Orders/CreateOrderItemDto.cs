namespace EasyReach_Application.DTOs.Orders
{
    public class CreateOrderItemDto
    {
        public Guid ProductVariantId { get; set; }
        public string ProductNameSnapshot { get; set; } = string.Empty;
        public string VariantNameSnapshot { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
