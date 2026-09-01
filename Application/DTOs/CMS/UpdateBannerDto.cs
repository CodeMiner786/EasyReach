using System;

namespace EasyReach_Application.DTOs.CMS
{
    /// <summary>
    /// Existing Banner update korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class UpdateBannerDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string? RedirectUrl { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
