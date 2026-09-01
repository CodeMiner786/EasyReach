using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.DTOs.LandingPages.LandingPageProductItems
{
    public class LandingPageProductItemDto
    {
        public Guid ProductId { get; set; }
        public decimal? CustomOfferPrice { get; set; }
        public int DisplayOrder { get; set; }
    }
}
