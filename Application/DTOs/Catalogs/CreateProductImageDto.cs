using System;

namespace EasyReach_Application.DTOs.Catalogs
{
    /// <summary>
    /// Notun ProductImage create korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class CreateProductImageDto
    {
        public Guid ProductId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public bool IsPrimary { get; set; }

        public int DisplayOrder { get; set; }
    }
}
