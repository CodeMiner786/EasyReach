using EasyReach_Application.DTOs.Payments;

namespace EasyReach_Application.ISslCommerzServices
{
    public interface ISslCommerzService
    {
        Task<string> InitiatePaymentAsync(InitiateSslCommerzPaymentDto dto);
        Task<bool> ValidateAndCompletePaymentAsync(SslCommerzCallbackDto callbackData);
    }
}
