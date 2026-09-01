using EasyReach_Domain.Common;
using EasyReach_Domain.Entities.Catalogs;

namespace EasyReach_Domain.Entities.Wishlists
{
    public class WishlistItem : AuditableEntity
    {
        public Guid WishlistId { get; set; }
        public Wishlist Wishlist { get; set; } = null!;

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    }
}
