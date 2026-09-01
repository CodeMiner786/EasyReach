namespace EasyReach_Application.DTOs.LandingPages
{
    public class LandingPageDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string HeroTitle { get; set; } = string.Empty;
        public string? HeroSubtitle { get; set; }
        public string? HeroImageUrl { get; set; }
        public string? CallToActionText { get; set; }
        public string? CallToActionUrl { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public bool IsPublished { get; set; }

        // Product Data
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal ProductRegularPrice { get; set; }
        public decimal OfferPrice { get; set; }

        // Front-end UI Toggles (বাটনটি দেখাবে কি না)
        public bool ShowWhatsAppButton { get; set; }
        public bool ShowDirectCheckoutForm { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
