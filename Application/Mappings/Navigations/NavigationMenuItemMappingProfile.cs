using AutoMapper;
using EasyReach_Application.DTOs.Navigations;
using EasyReach_Domain.Entities.Navigations;

namespace EasyReach_Application.Mappings.Navigations
{
    /// <summary>
    /// NavigationMenuItem entity ar tar DTO gulor (Create/Update/Response) majhe
    /// AutoMapper mapping. Property naam mile gele automatic map hoy,
    /// kono custom mapping lagle .ForMember() diye eikhane add korte hobe.
    /// </summary>
    public class NavigationMenuItemMappingProfile : Profile
    {
        public NavigationMenuItemMappingProfile()
        {
            CreateMap<NavigationMenuItem, NavigationMenuItemDto>();
            CreateMap<CreateNavigationMenuItemDto, NavigationMenuItem>();
            CreateMap<UpdateNavigationMenuItemDto, NavigationMenuItem>();
        }
    }
}
