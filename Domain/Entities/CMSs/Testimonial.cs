using EasyReach_Domain.Common;

namespace EasyReach_Domain.Entities.CMSs
{
    public class Testimonial : AuditableEntity
    {
        public string CustomerName { get; set; } = string.Empty;
        public string? Occupation { get; set; }
        public string? ImageUrl { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Rating { get; set; } // 1-5

        public bool IsApproved { get; set; } = false;
        public int DisplayOrder { get; set; }
    }
}
