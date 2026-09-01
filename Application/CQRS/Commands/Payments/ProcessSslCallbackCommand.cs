using EasyReach_Application.DTOs.Payments;
using MediatR;

namespace EasyReach_Application.CQRS.Commands.Payments
{
    public class ProcessSslCallbackCommand(SslCommerzCallbackDto callbackDto) : IRequest<bool>
    {
        public SslCommerzCallbackDto CallbackDto { get; set; } = callbackDto;
    }
}
