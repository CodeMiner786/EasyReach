using AutoMapper;
using EasyReach_Application.DTOs.Orders;
using EasyReach_Domain.Entities.Orders;

namespace EasyReach_Application.Mappings.Orders
{
    /// <summary>
    /// ShippingAddress entity ar tar DTO gulor (Create/Update/Response) majhe
    /// AutoMapper mapping. Property naam mile gele automatic map hoy,
    /// kono custom mapping lagle .ForMember() diye eikhane add korte hobe.
    /// </summary>
    public class ShippingAddressMappingProfile : Profile
    {
        public ShippingAddressMappingProfile()
        {
            CreateMap<ShippingAddress, ShippingAddressDto>();
            CreateMap<CreateShippingAddressDto, ShippingAddress>();
            CreateMap<UpdateShippingAddressDto, ShippingAddress>();
        }
    }
}
