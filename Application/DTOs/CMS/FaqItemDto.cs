using System;

namespace EasyReach_Application.DTOs.CMS
{
    /// <summary>
    /// FaqItem entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class FaqItemDto
    {
        public Guid Id { get; set; }

        public string Question { get; set; } = string.Empty;

        public string Answer { get; set; } = string.Empty;

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
