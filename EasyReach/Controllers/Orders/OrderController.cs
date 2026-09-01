using EasyReach_Application.CQRS.Commands.Orders;
using EasyReach_Application.CQRS.Querys.Orders;
using EasyReach_Domain.Common.Paginations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController(ISender mediator) : ControllerBase
    {
        // ১. নতুন অর্ডার তৈরি করার API
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            try
            {
                var result = await mediator.Send(command);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // ২. ID দিয়ে অর্ডারের ডিটেইলস পাওয়ার GET API
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var result = await mediator.Send(new GetOrderByIdQuery(id));
            if (result == null) return NotFound(new { message = "Order not found." });

            return Ok(result);
        }

        // ৩. ইউজারের সব অর্ডার হিস্ট্রি পাওয়ার GET API (Pagination সাপোর্ট সহ)
        [HttpGet("user-history/{userId:guid}")]
        public async Task<IActionResult> GetUserOrders(Guid userId, [FromQuery] PaginationParams paginationParams)
        {
            var result = await mediator.Send(new GetUserOrdersQuery
            {
                UserId = userId,
                PaginationParams = paginationParams
            });

            return Ok(result);
        }
    }
}

