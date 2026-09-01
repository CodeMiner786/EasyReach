using EasyReach_Application.CQRS.Commands.Orders;
using EasyReach_Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EasyReach.Controllers.AdminOrder
{
    [ApiController]
    [Route("api/admin/orders")]
    [Authorize(Roles = "Admin,Manager")]
    public class AdminOrdersController(ISender mediator) : ControllerBase
    {
        [HttpPut("{orderId:guid}/status")]
        public async Task<IActionResult> UpdateStatus(
            Guid orderId,
            [FromBody] UpdateOrderStatusRequest request)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _ = Guid.TryParse(userIdString, out Guid managerId);

            var command = new UpdateOrderStatusCommand(
                OrderId: orderId,
                Status: request.Status,
                PaymentStatus: request.PaymentStatus,
                ProcessedByUserId: managerId,
                Note: request.Note
            );

            var result = await mediator.Send(command);
            if (!result) return NotFound(new { message = "Order not found." });

            return Ok(new { message = "Order status updated successfully." });
        }
    }

    public record UpdateOrderStatusRequest(
        OrderStatus Status,
        PaymentStatus? PaymentStatus,
        string? Note);
}
