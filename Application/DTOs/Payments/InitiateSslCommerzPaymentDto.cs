namespace EasyReach_Application.DTOs.Payments
{
    public class InitiateSslCommerzPaymentDto
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
    }
}


// User ai from diye payment suru korbe