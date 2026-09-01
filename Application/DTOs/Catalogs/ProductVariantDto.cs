using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Catalogs
{
    /// <summary>
    /// ProductVariant entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class ProductVariantDto
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

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

        public DateTime CreatedAt { get; set; }
    }
}
