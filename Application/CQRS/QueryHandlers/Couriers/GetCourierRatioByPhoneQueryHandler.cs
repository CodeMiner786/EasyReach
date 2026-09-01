using EasyReach_Application.CourierService;
using EasyReach_Application.CQRS.Querys.Couriers;
using EasyReach_Application.DTOs.Couriers;
using MediatR;

namespace EasyReach_Application.CQRS.QueryHandlers.Couriers
{
    public class GetCourierRatioByPhoneQueryHandler(ICourierService courierService) : IRequestHandler<GetCourierRatioByPhoneQuery, CourierRatioResponseDto>
    {
        private readonly ICourierService _courierService = courierService;

        public async Task<CourierRatioResponseDto> Handle(GetCourierRatioByPhoneQuery request, CancellationToken cancellationToken)
        {
            return await _courierService.GetDeliveryRatioAsync(request.PhoneNumber);
        }
    }
}
