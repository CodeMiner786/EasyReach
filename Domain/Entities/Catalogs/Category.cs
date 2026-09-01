using EasyReach_Domain.Common;

namespace EasyReach_Domain.Entities.Catalogs
{

    // GhorerBazar er moto Category -> SubCategory structure.
    // Self-referencing kora hoyeche (ParentCategoryId) - jate jotoi
    // level er sub-category lage flexible thake (Honey -> Sundarban Honey).

    public class Category : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public string? IconUrl { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsFeatured { get; set; }

        // Self-reference - null hole eta top-level category
        public Guid? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; } = [];

        public ICollection<Product> Products { get; set; } = [];
    }
}
