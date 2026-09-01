using System;
using System.Collections.Generic;

namespace EasyReach_Application.DTOs.Catalogs
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string SKU { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        public Guid? BrandId { get; set; } // 👈 Nullable করা হলো যাতে রিকোয়েস্টে না পাঠালেও এরর না আসে
        public int Status { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsBestSelling { get; set; }
        public bool IsNewArrival { get; set; }
        public List<CreateProductVariantDto>? Variants { get; set; }
    }
}
