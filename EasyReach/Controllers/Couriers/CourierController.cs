using EasyReach_Application.CQRS.Commands.Couriers;
using EasyReach_Application.CQRS.Querys.Couriers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.Couriers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourierController(ISender mediator) : ControllerBase
    {
        // ১. কাস্টমারের ডেলিভারি রেশিও চেক করা (Fraud Check)
        [HttpGet("check-ratio/{phoneNumber}")]
        public async Task<IActionResult> CheckCustomerDeliveryRatio(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return BadRequest(new { message = "Phone number is required." });
            }

            var result = await mediator.Send(new GetCourierRatioByPhoneQuery(phoneNumber));
            return Ok(result);
        }

        // ২. Steadfast কুরিয়ার পার্সেল বুকিং এন্ডপয়েন্ট (Admin/Manager এর জন্য)
        [HttpPost("book-order/{orderId:guid}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> BookCourierOrder(Guid orderId)
        {
            var result = await mediator.Send(new CreateCourierOrderCommand(orderId));

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}

