using System;

namespace EasyReach_Application.DTOs.CMS
{
    /// <summary>
    /// Notun Banner create korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class CreateBannerDto
    {
        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string? RedirectUrl { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
