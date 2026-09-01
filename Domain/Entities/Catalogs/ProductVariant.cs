using EasyReach_Domain.Common;
using EasyReach_Domain.Enums;

namespace EasyReach_Domain.Entities.Catalogs
{

    // Ekta product er specific size/weight variant - ex: "Black Seed Honey 1kg".
    // Price, discount, stock shob ekhane thake.

    public class ProductVariant : AuditableEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public string VariantName { get; set; } = string.Empty; // "1kg", "500g"
        public string SKU { get; set; } = string.Empty;

        public decimal RegularPrice { get; set; }
        public decimal? DiscountPrice { get; set; }

        public decimal WeightOrVolume { get; set; }
        public UnitType Unit { get; set; }

        public int StockQuantity { get; set; }
        public StockStatus StockStatus { get; set; } = StockStatus.InStock;

        public bool IsDefault { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
