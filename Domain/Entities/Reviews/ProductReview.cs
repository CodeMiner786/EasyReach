using EasyReach_Domain.Common;
using EasyReach_Domain.Entities.Catalogs;
using EasyReach_Domain.Entities.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Domain.Entities.Reviews
{
    public class ProductReview : AuditableEntity
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public int Rating { get; set; } // 1 to 5 Stars
        public string Comment { get; set; } = string.Empty;

        public bool IsApproved { get; set; } = false; // Admin Moderation
        public bool IsVerifiedPurchase { get; set; } = false;
    }
}
