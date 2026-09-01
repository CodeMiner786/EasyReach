using EasyReach_Domain.Common;

namespace EasyReach_Domain.Entities.Catalogs
{
    public class Product : AuditableEntity
    {
        // ❌ public Guid Id { get; set; } বাদ দেওয়া হলো, কারণ এটি AuditableEntity থেকে ইনহেরিট হয়।

        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string SKU { get; set; } = string.Empty;

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        public Guid? BrandId { get; set; }
        public virtual Brand? Brand { get; set; }

        public int Status { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsBestSelling { get; set; }
        public bool IsNewArrival { get; set; }

        public virtual ICollection<ProductVariant> Variants { get; set; } = [];
        public virtual ICollection<ProductImage> Images { get; set; } = [];
    }
}

