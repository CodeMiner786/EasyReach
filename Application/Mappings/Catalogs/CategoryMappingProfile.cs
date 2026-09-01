using AutoMapper;
using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Application.Mappings.Catalogs
{
    /// <summary>
    /// Category entity ar tar DTO gulor (Create/Update/Response) majhe
    /// AutoMapper mapping. Property naam mile gele automatic map hoy,
    /// kono custom mapping lagle .ForMember() diye eikhane add korte hobe.
    /// </summary>
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
        }
    }
}
