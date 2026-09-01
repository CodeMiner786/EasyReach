using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.DTOs.LandingPages.LandingPageProductItems
{
    public class LandingPageResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string HeroTitle { get; set; } = string.Empty;
        public string? HeroSubtitle { get; set; }
        public string? HeroImageUrl { get; set; }
        public decimal OfferPrice { get; set; }
        public bool ShowDirectCheckoutForm { get; set; }
        public bool ShowWhatsAppButton { get; set; }
        public string? CallToActionText { get; set; }
        public string? CallToActionUrl { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public bool IsPublished { get; set; }

        public List<LandingPageProductResponseDto> Products { get; set; } = [];
    }
}
