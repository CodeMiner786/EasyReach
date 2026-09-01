using AutoMapper;
using EasyReach_Application.DTOs.Wishlists;
using EasyReach_Domain.Entities.Wishlists;

namespace EasyReach_Application.Mappings.Wishlists
{
    /// <summary>
    /// Wishlist entity theke WishlistDto te shudhu Response mapping -
    /// eta system/business-logic theke generate hoy, tai kono Create/Update
    /// mapping nei (matches the Create/Update DTO policy for this entity).
    /// </summary>
    public class WishlistMappingProfile : Profile
    {
        public WishlistMappingProfile()
        {
            CreateMap<Wishlist, WishlistDto>();
        }
    }
}
