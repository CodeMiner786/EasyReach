using EasyReach_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Domain.Entities.CMSs
{
    public class PageBanner : BaseEntity
    {
        public Guid PageId { get; set; }
        public Page Page { get; set; } = null!;

        public Guid BannerId { get; set; }
        public Banner Banner { get; set; } = null!;

        public int DisplayOrder { get; set; }
    }
}
