using EasyReach_Domain.Common;

namespace EasyReach_Domain.Entities.LandingPages;

public class LandingPage : AuditableEntity
{
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string HeroTitle { get; set; } = string.Empty;
    public string? HeroSubtitle { get; set; }
    public string? HeroImageUrl { get; set; }

    public decimal OfferPrice { get; set; }
    public bool ShowDirectCheckoutForm { get; set; } = true;
    public bool ShowWhatsAppButton { get; set; } = true;

    public string? CallToActionText { get; set; }
    public string? CallToActionUrl { get; set; }

    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public bool IsPublished { get; set; } = false;

    public ICollection<LandingPageProduct> LandingPageProducts { get; set; } = [];
}

