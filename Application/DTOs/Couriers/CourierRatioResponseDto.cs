namespace EasyReach_Application.DTOs.Couriers
{
    public class CourierRatioResponseDto
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public int TotalDelivered { get; set; }
        public int TotalCancelled { get; set; }
        public double SuccessRate { get; set; }
    }
}
