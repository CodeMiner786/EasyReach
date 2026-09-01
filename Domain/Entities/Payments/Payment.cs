using EasyReach_Domain.Common;
using EasyReach_Domain.Entities.Orders;
using EasyReach_Domain.Enums;

namespace EasyReach_Domain.Entities.Payments
{
    public class Payment : AuditableEntity
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public decimal Amount { get; set; }
        public decimal StoreAmount { get; set; } // চার্জ কাটার পর জমা হওয়া নিট টাকা
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        // SSLCommerz Transaction & MFS Tracking Fields
        public string TransactionId { get; set; } = string.Empty; // SSLCommerz tran_id
        public string? ValidationId { get; set; } // SSLCommerz val_id
        public string? BankTransactionId { get; set; } // bKash / Nagad Transaction ID (TrxID)
        public string? CardType { get; set; } // BKASH-BKASH, NAGAD-NAGAD, etc.
        public string? CardIssuer { get; set; } // Mobile Banking Issuer Info
        public string? CardBrand { get; set; } // MFS Channel Brand Name
        public string? GatewayResponse { get; set; } // Audit Log Response JSON

        public DateTime? PaidAt { get; set; }
    }
}
