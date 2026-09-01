using System;
using EasyReach_Domain.Common;

namespace EasyReach_Domain.Entities.CMSs
{
    public class Banner : AuditableEntity
    {
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string? RedirectUrl { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
