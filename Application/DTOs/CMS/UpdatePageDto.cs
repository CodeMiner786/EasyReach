using System;

namespace EasyReach_Application.DTOs.CMS
{
    /// <summary>
    /// Existing Page update korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class UpdatePageDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public bool IsPublished { get; set; }
    }
}
