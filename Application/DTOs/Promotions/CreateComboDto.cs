using System;

namespace EasyReach_Application.DTOs.Promotions
{
    /// <summary>
    /// Notun Combo create korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class CreateComboDto
    {
        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public decimal ComboPrice { get; set; }

        public decimal RegularPrice { get; set; }

        public bool IsActive { get; set; }
    }
}
