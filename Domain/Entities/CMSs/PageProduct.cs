using EasyReach_Domain.Common;
using EasyReach_Domain.Entities.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Domain.Entities.CMSs
{
    public class PageProduct : BaseEntity
    {
        public Guid PageId { get; set; }
        public Page Page { get; set; } = null!;

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int DisplayOrder { get; set; }
        public string? SectionTitle { get; set; }
    }
}
