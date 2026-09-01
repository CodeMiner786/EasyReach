using EasyReach_Application.CQRS.Commands.Payments;
using EasyReach_Application.CQRS.Querys.Payments;
using EasyReach_Application.DTOs.Payments;
using EasyReach_Domain.Common.Paginations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.Payments
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController(ISender mediator, IConfiguration configuration) : ControllerBase
    {
        private string FrontendUrl => configuration["FrontendUrl"] ?? "http://localhost:3000";

        [HttpPost("initiate")]
        [AllowAnonymous]
        public async Task<IActionResult> InitiatePayment([FromBody] InitiatePaymentCommand command)
        {
            var gatewayUrl = await mediator.Send(command);
            return Ok(new { paymentUrl = gatewayUrl });
        }

        [HttpPost("success")]
        [AllowAnonymous]
        public async Task<IActionResult> PaymentSuccess([FromForm] SslCommerzCallbackDto callbackDto)
        {
            var isSuccess = await mediator.Send(new ProcessSslCallbackCommand(callbackDto));

            if (isSuccess)
            {
                return Redirect($"{FrontendUrl}/payment-success?tranId={callbackDto.TranId}");
            }

            return Redirect($"{FrontendUrl}/payment-failed?tranId={callbackDto.TranId}");
        }

        [HttpPost("fail")]
        [AllowAnonymous]
        public IActionResult PaymentFail([FromForm] SslCommerzCallbackDto callbackDto)
        {
            return Redirect($"{FrontendUrl}/payment-failed?tranId={callbackDto.TranId}");
        }

        [HttpPost("cancel")]
        [AllowAnonymous]
        public IActionResult PaymentCancel([FromForm] SslCommerzCallbackDto callbackDto)
        {
            return Redirect($"{FrontendUrl}/payment-cancelled?tranId={callbackDto.TranId}");
        }

        [HttpPost("ipn")]
        [AllowAnonymous]
        public async Task<IActionResult> PaymentIPN([FromForm] SslCommerzCallbackDto callbackDto)
        {
            await mediator.Send(new ProcessSslCallbackCommand(callbackDto));
            return Ok();
        }

        // ==========================================
        // 🚀 GET ENDPOINTS
        // ==========================================

        [HttpGet("details/{tranId}")]
        [Authorize]
        public async Task<IActionResult> GetPaymentDetails(string tranId)
        {
            var result = await mediator.Send(new GetPaymentByTranIdQuery(tranId));
            if (result == null) return NotFound(new { message = "Payment transaction not found." });

            return Ok(result);
        }

        [HttpGet("user-history/{userId:guid}")]
        [Authorize]
        public async Task<IActionResult> GetUserPaymentHistory(Guid userId, [FromQuery] PaginationParams paginationParams)
        {
            var result = await mediator.Send(new GetUserPaymentHistoryQuery
            {
                UserId = userId,
                PaginationParams = paginationParams
            });

            return Ok(result);
        }
    }
}

