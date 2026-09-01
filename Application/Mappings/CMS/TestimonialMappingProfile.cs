using AutoMapper;
using EasyReach_Application.DTOs.CMS;
using EasyReach_Domain.Entities.CMSs;

namespace EasyReach_Application.Mappings.CMS
{
    /// <summary>
    /// Testimonial entity ar tar DTO gulor (Create/Update/Response) majhe
    /// AutoMapper mapping. Property naam mile gele automatic map hoy,
    /// kono custom mapping lagle .ForMember() diye eikhane add korte hobe.
    /// </summary>
    public class TestimonialMappingProfile : Profile
    {
        public TestimonialMappingProfile()
        {
            CreateMap<Testimonial, TestimonialDto>();
            CreateMap<CreateTestimonialDto, Testimonial>();
            CreateMap<UpdateTestimonialDto, Testimonial>();
        }
    }
}
