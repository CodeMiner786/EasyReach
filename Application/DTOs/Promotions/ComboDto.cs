using System;

namespace EasyReach_Application.DTOs.Promotions
{
    /// <summary>
    /// Combo entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class ComboDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public decimal ComboPrice { get; set; }

        public decimal RegularPrice { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
