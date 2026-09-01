using System;

namespace EasyReach_Application.DTOs.CMS
{
    /// <summary>
    /// Notun FaqItem create korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class CreateFaqItemDto
    {
        public string Question { get; set; } = string.Empty;

        public string Answer { get; set; } = string.Empty;

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }
    }
}
