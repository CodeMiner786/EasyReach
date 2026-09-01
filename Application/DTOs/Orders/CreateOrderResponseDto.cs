using EasyReach_Application.DTOs.Couriers;

namespace EasyReach_Application.DTOs.Orders
{
    public class CreateOrderResponseDto
    {
        public Guid OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public decimal GrandTotal { get; set; }
        public CourierRatioResponseDto CourierSuccessRatio { get; set; } = null!;
    }
}
