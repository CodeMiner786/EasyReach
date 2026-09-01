using AutoMapper;
using EasyReach_Application.DTOs.Payments;
using EasyReach_Domain.Entities.Payments;

namespace EasyReach_Application.Mappings.Payments
{
    public class PaymentMappingProfile : Profile
    {
        public PaymentMappingProfile()
        {
            CreateMap<Payment, PaymentDto>();
        }
    }
}
