using AutoMapper;
using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Application.Mappings.Catalogs
{
    /// <summary>
    /// Brand entity ar tar DTO gulor (Create/Update/Response) majhe
    /// AutoMapper mapping. Property naam mile gele automatic map hoy,
    /// kono custom mapping lagle .ForMember() diye eikhane add korte hobe.
    /// </summary>
    public class BrandMappingProfile : Profile
    {
        public BrandMappingProfile()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<CreateBrandDto, Brand>();
            CreateMap<UpdateBrandDto, Brand>();
        }
    }
}
