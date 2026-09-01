using AutoMapper;
using EasyReach_Application.CQRS.Commands.Orders;
using EasyReach_Application.DTOs.Orders;
using EasyReach_Domain.Entities.Orders;

namespace EasyReach_Application.Mappings.Orders
{
    /// <summary>
    /// Order entity theke OrderDto te shudhu Response mapping -
    /// eta system/business-logic theke generate hoy, tai kono Create/Update
    /// mapping nei (matches the Create/Update DTO policy for this entity).
    /// </summary>
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderDto>();

            // CreateOrderCommand -> Order Mapping
            CreateMap<CreateOrderCommand, Order>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.ShippingAddress, opt => opt.Ignore()); // Address আলাদাভাবে Handle করা হয়
        }
    }
}
