using AutoMapper;
using EasyReach_Application.DTOs.Identities;
using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Application.Mappings.Identities
{
    /// <summary>
    /// ApplicationUser entity ar tar DTO gulor majhe AutoMapper mapping.
    /// CreateApplicationUserDto.Password field ta PasswordHash e directly map
    /// kora hoyni - Service layer e hash kore tarpor manually set korte hobe,
    /// tai eikhane Ignore() kora ache (plain password kokhono direct DB e jabe na).
    /// </summary>
    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>();

            CreateMap<CreateApplicationUserDto, ApplicationUser>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<UpdateApplicationUserDto, ApplicationUser>();
        }
    }
}
