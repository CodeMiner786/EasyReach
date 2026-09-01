using AutoMapper;
using EasyReach_Application.DTOs.Identities;
using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Application.Mappings.Identities
{
    /// <summary>
    /// RefreshToken entity theke RefreshTokenDto te shudhu Response mapping -
    /// eta system/business-logic theke generate hoy, tai kono Create/Update
    /// mapping nei (matches the Create/Update DTO policy for this entity).
    /// </summary>
    public class RefreshTokenMappingProfile : Profile
    {
        public RefreshTokenMappingProfile()
        {
            CreateMap<RefreshToken, RefreshTokenDto>();
        }
    }
}
