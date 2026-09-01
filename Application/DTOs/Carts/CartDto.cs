using System;

namespace EasyReach_Application.DTOs.Carts
{
    /// <summary>
    /// Cart - system/business-logic theke generate hoy (Order placement, Cart operation etc.), tai shudhu Response DTO - kono Create/Update admin form nei.
    /// </summary>
    public class CartDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
