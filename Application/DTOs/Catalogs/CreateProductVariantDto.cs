using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Catalogs
{
    public class CreateProductVariantDto
    {
        public Guid? ProductId { get; set; }

        public string VariantName { get; set; } = string.Empty;

        public string SKU { get; set; } = string.Empty;

        public decimal RegularPrice { get; set; }

        public decimal? DiscountPrice { get; set; }

        public decimal WeightOrVolume { get; set; }

        public UnitType Unit { get; set; }

        public int StockQuantity { get; set; }

        public StockStatus StockStatus { get; set; }

        public bool IsDefault { get; set; }

        public bool IsActive { get; set; }
    }
}
