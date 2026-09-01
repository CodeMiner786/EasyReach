namespace EasyReach_Application.DTOs.LandingPages
{
    public class CreateLandingPageDto
    {
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string HeroTitle { get; set; } = string.Empty;
        public string? HeroSubtitle { get; set; }
        public string? HeroImageUrl { get; set; }
        public string? CallToActionText { get; set; }
        public string? CallToActionUrl { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public bool IsPublished { get; set; } = false;

        public Guid ProductId { get; set; }
        public decimal OfferPrice { get; set; }
        public bool ShowWhatsAppButton { get; set; } = true;
        public bool ShowDirectCheckoutForm { get; set; } = true;
    }
}
