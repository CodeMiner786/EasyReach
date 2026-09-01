using System;

namespace EasyReach_Application.DTOs.Catalogs
{
    /// <summary>
    /// Category entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class CategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public string? IconUrl { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public bool IsFeatured { get; set; }

        public Guid? ParentCategoryId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
