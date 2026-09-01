using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Promotions
{
    /// <summary>
    /// Notun Discount create korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class CreateDiscountDto
    {
        public string Name { get; set; } = string.Empty;

        public DiscountType Type { get; set; }

        public decimal Value { get; set; }

        public Guid? ProductVariantId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }
    }
}
