using AutoMapper;
using EasyReach_Application.DTOs.CMS;
using EasyReach_Domain.Entities.CMSs;

namespace EasyReach_Application.Mappings.CMS
{
    /// <summary>
    /// Banner entity ar tar DTO gulor (Create/Update/Response) majhe
    /// AutoMapper mapping. Property naam mile gele automatic map hoy,
    /// kono custom mapping lagle .ForMember() diye eikhane add korte hobe.
    /// </summary>
    public class BannerMappingProfile : Profile
    {
        public BannerMappingProfile()
        {
            CreateMap<Banner, BannerDto>();
            CreateMap<CreateBannerDto, Banner>();
            CreateMap<UpdateBannerDto, Banner>();
        }
    }
}
