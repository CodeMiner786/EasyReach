using EasyReach_Domain.Common;

namespace EasyReach_Domain.Entities.CMSs
{
    public class FaqItem : AuditableEntity
    {
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
