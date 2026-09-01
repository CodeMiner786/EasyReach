using System;

namespace EasyReach_Application.DTOs.Catalogs
{
    /// <summary>
    /// ProductImage entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class ProductImageDto
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public bool IsPrimary { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
