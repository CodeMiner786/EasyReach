using EasyReach_Application.CQRS.Commands.Payments;
using EasyReach_Application.ISslCommerzServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.CommandHandlers.Payments
{
    public class ProcessSslCallbackCommandHandler(ISslCommerzService sslCommerzService)
        : IRequestHandler<ProcessSslCallbackCommand, bool>
    {
        public async Task<bool> Handle(ProcessSslCallbackCommand request, CancellationToken cancellationToken)
        {
            return await sslCommerzService.ValidateAndCompletePaymentAsync(request.CallbackDto);
        }
    }
}
