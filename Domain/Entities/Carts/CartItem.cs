using EasyReach_Domain.Common;
using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Domain.Entities.Carts
{
    public class CartItem : AuditableEntity
    {
        public Guid CartId { get; set; }
        public Cart Cart { get; set; } = null!;

        public Guid ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; } = null!;

        public int Quantity { get; set; }
        public decimal UnitPriceSnapshot { get; set; }
    }
}
