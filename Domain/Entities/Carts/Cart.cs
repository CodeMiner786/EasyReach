using EasyReach_Domain.Common;

namespace EasyReach_Domain.Entities.Carts
{
    public class Cart : AuditableEntity
    {
        public Guid UserId { get; set; }

        public ICollection<CartItem> Items { get; set; } = [];
    }
}
