using EasyReach_Application.DTOs.Couriers;
using MediatR;

namespace EasyReach_Application.CQRS.Querys.Couriers
{
    public record GetCourierRatioByPhoneQuery(string PhoneNumber) : IRequest<CourierRatioResponseDto>;
}
