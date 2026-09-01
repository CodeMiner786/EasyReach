using System;

namespace EasyReach_Application.DTOs.CMS
{
    /// <summary>
    /// Banner entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class BannerDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string? RedirectUrl { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
