using AutoMapper;
using EasyReach_Application.DTOs.Identities;
using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Application.Mappings.Identities
{
    /// <summary>
    /// PasswordResetToken entity theke PasswordResetTokenDto te shudhu Response mapping -
    /// eta system/business-logic theke generate hoy, tai kono Create/Update
    /// mapping nei (matches the Create/Update DTO policy for this entity).
    /// </summary>
    public class PasswordResetTokenMappingProfile : Profile
    {
        public PasswordResetTokenMappingProfile()
        {
            CreateMap<PasswordResetToken, PasswordResetTokenDto>();
        }
    }
}
