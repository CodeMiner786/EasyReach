using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Promotions
{
    /// <summary>
    /// Discount entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class DiscountDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DiscountType Type { get; set; }

        public decimal Value { get; set; }

        public Guid? ProductVariantId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
