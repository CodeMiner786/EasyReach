using AutoMapper;
using EasyReach_Application.DTOs.Orders;
using EasyReach_Domain.Entities.Orders;

namespace EasyReach_Application.Mappings.Orders
{
    /// <summary>
    /// OrderItem entity theke OrderItemDto te shudhu Response mapping -
    /// eta system/business-logic theke generate hoy, tai kono Create/Update
    /// mapping nei (matches the Create/Update DTO policy for this entity).
    /// </summary>
    public class OrderItemMappingProfile : Profile
    {
        public OrderItemMappingProfile()
        {
            CreateMap<OrderItem, OrderItemDto>();

            // Create Order-এর জন্য DTO -> Entity mapping
            CreateMap<CreateOrderItemDto, OrderItem>()
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.UnitPrice * src.Quantity));
        }
    }
}
