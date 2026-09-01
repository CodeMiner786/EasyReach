using System;

namespace EasyReach_Application.DTOs.Catalogs
{
    /// <summary>
    /// Existing ProductImage update korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class UpdateProductImageDto
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public bool IsPrimary { get; set; }

        public int DisplayOrder { get; set; }
    }
}
