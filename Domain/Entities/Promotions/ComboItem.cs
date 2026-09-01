using EasyReach_Domain.Common;
using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Domain.Entities.Promotions
{
    public class ComboItem : AuditableEntity
    {
        public Guid ComboId { get; set; }
        public Combo Combo { get; set; } = null!;

        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; } = null!;

        public int Quantity { get; set; } = 1;
    }
}
