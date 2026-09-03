using AutoMapper;
using EasyReach_Application.DTOs.CMS;
using EasyReach_Domain.Entities.CMSs;

namespace EasyReach_Application.Mappings.CMS
{
    public class PageMappingProfile : Profile
    {
        public PageMappingProfile()
        {
            CreateMap<Page, PageDto>()
                .ForMember(dest => dest.Banners, opt => opt.MapFrom(src => src.PageBanners.OrderBy(pb => pb.DisplayOrder).Select(pb => pb.Banner)))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.PageProducts.OrderBy(pp => pp.DisplayOrder).Select(pp => new PageProductItemDto
                {
                    ProductId = pp.ProductId,
                    Name = pp.Product != null ? pp.Product.Name : string.Empty,
                    Slug = pp.Product != null ? pp.Product.Slug : string.Empty,
                    ShortDescription = pp.Product != null ? pp.Product.ShortDescription : null,
                    CategoryName = pp.Product != null && pp.Product.Category != null ? pp.Product.Category.Name : string.Empty,
                    BrandName = pp.Product != null && pp.Product.Brand != null ? pp.Product.Brand.Name : null,
                    IsFeatured = pp.Product != null && pp.Product.IsFeatured,
                    IsBestSelling = pp.Product != null && pp.Product.IsBestSelling,
                    IsNewArrival = pp.Product != null && pp.Product.IsNewArrival,
                    DisplayOrder = pp.DisplayOrder,
                    SectionTitle = pp.SectionTitle,

                    BasePrice = pp.Product != null && pp.Product.Variants.Count > 0
                        ? (pp.Product.Variants.FirstOrDefault(v => v.IsDefault) ?? pp.Product.Variants.First()).RegularPrice
                        : 0,

                    DiscountPrice = pp.Product != null && pp.Product.Variants.Count > 0
                        ? (pp.Product.Variants.FirstOrDefault(v => v.IsDefault) ?? pp.Product.Variants.First()).DiscountPrice
                        : null,

                    ImageUrl = pp.Product != null && pp.Product.Images.Count > 0 ? pp.Product.Images.First().ImageUrl : null
                })));

            CreateMap<CreatePageDto, Page>();
            CreateMap<UpdatePageDto, Page>();
        }
    }
}

