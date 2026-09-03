using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.DTOs.CMS
{
    public class PageProductItemDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? BrandName { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsBestSelling { get; set; }
        public bool IsNewArrival { get; set; }
        public int DisplayOrder { get; set; }
        public string? SectionTitle { get; set; }

        public decimal BasePrice { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string? ImageUrl { get; set; }
    }
}
