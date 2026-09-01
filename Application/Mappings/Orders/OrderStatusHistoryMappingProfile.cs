using AutoMapper;
using EasyReach_Application.DTOs.Orders;
using EasyReach_Domain.Entities.Orders;

namespace EasyReach_Application.Mappings.Orders
{
    /// <summary>
    /// OrderStatusHistory entity theke OrderStatusHistoryDto te shudhu Response mapping -
    /// eta system/business-logic theke generate hoy, tai kono Create/Update
    /// mapping nei (matches the Create/Update DTO policy for this entity).
    /// </summary>
    public class OrderStatusHistoryMappingProfile : Profile
    {
        public OrderStatusHistoryMappingProfile()
        {
            CreateMap<OrderStatusHistory, OrderStatusHistoryDto>();
        }
    }
}
