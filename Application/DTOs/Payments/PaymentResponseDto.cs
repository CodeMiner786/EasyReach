using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Payments
{
    public class PaymentResponseDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public decimal StoreAmount { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
        public string TransactionId { get; set; } = string.Empty;
        public string? BankTransactionId { get; set; } // bKash / Nagad TrxID
        public string? CardType { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
