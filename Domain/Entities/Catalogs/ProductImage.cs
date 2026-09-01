using EasyReach_Domain.Common;

namespace EasyReach_Domain.Entities.Catalogs
{
    public class ProductImage : AuditableEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public int DisplayOrder { get; set; }
    }
}
