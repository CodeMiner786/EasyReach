using AutoMapper;
using EasyReach_Application.DTOs.LandingPages;
using EasyReach_Application.DTOs.LandingPages.LandingPageProductItems;
using EasyReach_Domain.Entities.LandingPages;

namespace EasyReach_Application.Mappings.LandingPages;

public class LandingPageProfile : Profile
{
    public LandingPageProfile()
    {
        // 1. LandingPageProduct Entity -> LandingPageProductResponseDto
        CreateMap<LandingPageProduct, LandingPageProductResponseDto>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))

            // 🚀 ১. IsDefault ভ্যারিয়েন্ট থাকলে তার RegularPrice নেওয়া হবে, না থাকলে ১ম ভ্যারিয়েন্টের RegularPrice
            .ForMember(dest => dest.BasePrice, opt => opt.MapFrom(src =>
                (src.Product.Variants.FirstOrDefault(v => v.IsDefault) ?? src.Product.Variants.FirstOrDefault()) != null
                    ? (src.Product.Variants.FirstOrDefault(v => v.IsDefault) ?? src.Product.Variants.FirstOrDefault())!.RegularPrice
                    : 0))

            .ForMember(dest => dest.CustomOfferPrice, opt => opt.MapFrom(src => src.CustomOfferPrice))
            .ForMember(dest => dest.DisplayOrder, opt => opt.MapFrom(src => src.DisplayOrder));

        // 2. LandingPage Entity -> LandingPageResponseDto
        CreateMap<LandingPage, LandingPageResponseDto>()
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.LandingPageProducts));
    }
}

