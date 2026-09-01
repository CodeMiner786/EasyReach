using EasyReach_Application.DTOs.Couriers;

namespace EasyReach_Application.CourierService
{
    public interface ICourierService
    {
        Task<CourierRatioResponseDto> GetDeliveryRatioAsync(string phoneNumber);
        Task<CourierBookingResponseDto> CreateOrderAsync(CourierOrderRequestDto request);
    }
}
