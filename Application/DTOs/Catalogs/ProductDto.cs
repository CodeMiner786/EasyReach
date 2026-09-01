using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Catalogs
{
    /// <summary>
    /// Product entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class ProductDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string? ShortDescription { get; set; }

        public string? Description { get; set; }

        public string SKU { get; set; } = string.Empty;

        public Guid CategoryId { get; set; }

        public Guid? BrandId { get; set; }

        public ProductStatus Status { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsBestSelling { get; set; }

        public bool IsNewArrival { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
