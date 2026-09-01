using System;

namespace EasyReach_Application.DTOs.Promotions
{
    /// <summary>
    /// Existing ComboItem update korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class UpdateComboItemDto
    {
        public Guid Id { get; set; }

        public Guid ComboId { get; set; }

        public Guid ProductVariantId { get; set; }

        public int Quantity { get; set; }
    }
}
