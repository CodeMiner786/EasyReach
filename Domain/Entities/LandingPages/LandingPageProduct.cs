using EasyReach_Domain.Common;
using EasyReach_Domain.Entities.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Domain.Entities.LandingPages
{
    public class LandingPageProduct : BaseEntity
    {
        public Guid LandingPageId { get; set; }
        public LandingPage LandingPage { get; set; } = null!;

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public decimal? CustomOfferPrice { get; set; }
        public int DisplayOrder { get; set; }
    }
}
