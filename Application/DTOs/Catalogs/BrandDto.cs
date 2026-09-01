using System;

namespace EasyReach_Application.DTOs.Catalogs
{
    /// <summary>
    /// Brand entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class BrandDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string? LogoUrl { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
