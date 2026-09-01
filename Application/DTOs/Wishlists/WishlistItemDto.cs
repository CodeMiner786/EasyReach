using System;

namespace EasyReach_Application.DTOs.Wishlists
{
    /// <summary>
    /// WishlistItem - system/business-logic theke generate hoy (Order placement, Cart operation etc.), tai shudhu Response DTO - kono Create/Update admin form nei.
    /// </summary>
    public class WishlistItemDto
    {
        public Guid Id { get; set; }

        public Guid WishlistId { get; set; }

        public Guid ProductId { get; set; }

        public DateTime AddedAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
