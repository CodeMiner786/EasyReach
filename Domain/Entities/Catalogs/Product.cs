using EasyReach_Domain.Common;
using EasyReach_Domain.Enums;

namespace EasyReach_Domain.Entities.Catalogs
{

    // Main Product entity. Actual price/stock ProductVariant e thake
    // (jehetu ekta product er multiple size/weight thakte pare - 500g, 1kg).

    public class Product : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string SKU { get; set; } = string.Empty;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public Guid? BrandId { get; set; }
        public Brand? Brand { get; set; }

        public ProductStatus Status { get; set; } = ProductStatus.Draft;

        public bool IsFeatured { get; set; }
        public bool IsBestSelling { get; set; }
        public bool IsNewArrival { get; set; }

        // Kon manager/admin ei product ta upload korlo
        public new Guid CreatedByUserId { get; set; }

        public ICollection<ProductVariant> Variants { get; set; } = [];
        public ICollection<ProductImage> Images { get; set; } = [];
    }
}
