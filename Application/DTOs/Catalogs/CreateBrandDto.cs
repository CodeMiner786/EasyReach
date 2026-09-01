using System;

namespace EasyReach_Application.DTOs.Catalogs
{
    /// <summary>
    /// Notun Brand create korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class CreateBrandDto
    {
        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string? LogoUrl { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }
    }
}
