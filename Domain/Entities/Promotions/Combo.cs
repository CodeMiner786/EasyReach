using EasyReach_Domain.Common;

namespace EasyReach_Domain.Entities.Promotions
{
    // GhorerBazar er "Exclusive Combo Deals" er moto bundle offer.
    public class Combo : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

        public decimal ComboPrice { get; set; }
        public decimal RegularPrice { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<ComboItem> Items { get; set; } = [];
    }
}
