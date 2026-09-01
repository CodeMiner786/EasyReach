using AutoMapper;
using EasyReach_Application.DTOs.Promotions;
using EasyReach_Domain.Entities.Promotions;

namespace EasyReach_Application.Mappings.Promotions
{
    /// <summary>
    /// ComboItem entity ar tar DTO gulor (Create/Update/Response) majhe
    /// AutoMapper mapping. Property naam mile gele automatic map hoy,
    /// kono custom mapping lagle .ForMember() diye eikhane add korte hobe.
    /// </summary>
    public class ComboItemMappingProfile : Profile
    {
        public ComboItemMappingProfile()
        {
            CreateMap<ComboItem, ComboItemDto>();
            CreateMap<CreateComboItemDto, ComboItem>();
            CreateMap<UpdateComboItemDto, ComboItem>();
        }
    }
}
