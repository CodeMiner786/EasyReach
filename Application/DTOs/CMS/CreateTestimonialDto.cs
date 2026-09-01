using System;

namespace EasyReach_Application.DTOs.CMS
{
    /// <summary>
    /// Notun Testimonial create korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class CreateTestimonialDto
    {
        public string CustomerName { get; set; } = string.Empty;

        public string? Occupation { get; set; }

        public string? ImageUrl { get; set; }

        public string Message { get; set; } = string.Empty;

        public int Rating { get; set; }

        public bool IsApproved { get; set; }

        public int DisplayOrder { get; set; }
    }
}
