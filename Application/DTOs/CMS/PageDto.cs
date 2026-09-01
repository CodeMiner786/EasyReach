using System;

namespace EasyReach_Application.DTOs.CMS
{
    /// <summary>
    /// Page entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class PageDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public bool IsPublished { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
