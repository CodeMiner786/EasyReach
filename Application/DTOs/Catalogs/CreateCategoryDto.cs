using System;

namespace EasyReach_Application.DTOs.Catalogs
{
    /// <summary>
    /// Notun Category create korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class CreateCategoryDto
    {
        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public string? IconUrl { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public bool IsFeatured { get; set; }

        public Guid? ParentCategoryId { get; set; }
    }
}
