using EasyReach_Domain.Common;

namespace EasyReach_Domain.Entities.CMSs
{
    public class Page : AuditableEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsPublished { get; set; } = true;

        public virtual ICollection<PageBanner> PageBanners { get; set; } = [];
        public virtual ICollection<PageProduct> PageProducts { get; set; } = [];
    }
}
