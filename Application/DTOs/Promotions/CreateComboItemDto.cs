using System;

namespace EasyReach_Application.DTOs.Promotions
{
    /// <summary>
    /// Notun ComboItem create korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class CreateComboItemDto
    {
        public Guid ComboId { get; set; }

        public Guid ProductVariantId { get; set; }

        public int Quantity { get; set; }
    }
}
