using System;

namespace EasyReach_Application.DTOs.CMS
{
    /// <summary>
    /// Notun Page create korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class CreatePageDto
    {
        public string Title { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public bool IsPublished { get; set; }
    }
}
