using EasyReach_Domain.Common;

namespace EasyReach_Domain.Entities.Wishlists
{
    public class Wishlist : AuditableEntity
    {
        public Guid UserId { get; set; }

        public ICollection<WishlistItem> Items { get; set; } = [];
    }
}
