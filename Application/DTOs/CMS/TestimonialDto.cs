using System;

namespace EasyReach_Application.DTOs.CMS
{
    /// <summary>
    /// Testimonial entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class TestimonialDto
    {
        public Guid Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string? Occupation { get; set; }

        public string? ImageUrl { get; set; }

        public string Message { get; set; } = string.Empty;

        public int Rating { get; set; }

        public bool IsApproved { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
