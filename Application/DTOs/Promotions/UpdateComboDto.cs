using System;

namespace EasyReach_Application.DTOs.Promotions
{
    /// <summary>
    /// Existing Combo update korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class UpdateComboDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public decimal ComboPrice { get; set; }

        public decimal RegularPrice { get; set; }

        public bool IsActive { get; set; }
    }
}
