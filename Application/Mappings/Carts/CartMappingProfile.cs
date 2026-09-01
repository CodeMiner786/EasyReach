using AutoMapper;
using EasyReach_Application.DTOs.Carts;
using EasyReach_Domain.Entities.Carts;

namespace EasyReach_Application.Mappings.Carts
{
    /// <summary>
    /// Cart entity theke CartDto te shudhu Response mapping -
    /// eta system/business-logic theke generate hoy, tai kono Create/Update
    /// mapping nei (matches the Create/Update DTO policy for this entity).
    /// </summary>
    public class CartMappingProfile : Profile
    {
        public CartMappingProfile()
        {
            CreateMap<Cart, CartDto>();
        }
    }
}
