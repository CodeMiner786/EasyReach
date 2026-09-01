using AutoMapper;
using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Application.Mappings.Catalogs
{
    /// <summary>
    /// Product entity ar tar DTO gulor (Create/Update/Response) majhe
    /// AutoMapper mapping. Property naam mile gele automatic map hoy,
    /// kono custom mapping lagle .ForMember() diye eikhane add korte hobe.
    /// </summary>
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
