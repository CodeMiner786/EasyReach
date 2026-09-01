using AutoMapper;
using EasyReach_Application.DTOs.Promotions;
using EasyReach_Domain.Entities.Promotions;

namespace EasyReach_Application.Mappings.Promotions
{
    /// <summary>
    /// Discount entity ar tar DTO gulor (Create/Update/Response) majhe
    /// AutoMapper mapping. Property naam mile gele automatic map hoy,
    /// kono custom mapping lagle .ForMember() diye eikhane add korte hobe.
    /// </summary>
    public class DiscountMappingProfile : Profile
    {
        public DiscountMappingProfile()
        {
            CreateMap<Discount, DiscountDto>();
            CreateMap<CreateDiscountDto, Discount>();
            CreateMap<UpdateDiscountDto, Discount>();
        }
    }
}
