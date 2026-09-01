using System;
using EasyReach_Domain.Common;
using EasyReach_Domain.Enums;

namespace EasyReach_Domain.Entities.Promotions
{
    // Time-bound campaign discount (Flash Sale, Offer Zone er jonno).
    public class Discount : AuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public DiscountType Type { get; set; }
        public decimal Value { get; set; }

        public Guid? ProductVariantId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
