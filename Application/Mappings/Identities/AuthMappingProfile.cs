using AutoMapper;
using EasyReach_Application.DTOs.Identities.Auth;
using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Application.Mappings.Identities
{
    /// <summary>
    /// RegisterDto theke notun ApplicationUser banano - Password field ta
    /// PasswordHash e direct map hoy na (Ignore kora hoyeche), Service layer
    /// e hash kore manually set korte hobe. UserType/RoleId o eikhane map
    /// hoy na - registration shomoy shob shomoy UserType.Customer thakbe,
    /// eta Service layer e explicitly set kora উচিত।
    /// </summary>
    public class AuthMappingProfile : Profile
    {
        public AuthMappingProfile()
        {
            CreateMap<RegisterDto, ApplicationUser>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
        }
    }
}
