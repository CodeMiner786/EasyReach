using EasyReach_Application.CQRS.Commands.Carts;
using EasyReach_Application.CQRS.Querys.Carts;
using EasyReach_Application.DTOs.Carts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EasyReach.Controllers.Cart
{
    [Authorize] // 🔐 পুরো 컨트롤ারই এখন প্রটেক্টেড, লগইন ছাড়া কার্ট দেখা বা এক্সেস করা যাবে না
    [ApiController]
    [Route("api/[controller]")]
    public class CartController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        // 🚀 ১. টোকেন থেকে অটোমেটিক ইউজারের ID রিড হবে, কোনো ম্যানুয়াল input লাগবে না
        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var userId = GetUserId();
            var result = await _mediator.Send(new GetCartByUserIdQuery(userId));

            if (result is null)
            {
                return Ok(new
                {
                    Success = true,
                    Message = "Cart is empty.",
                    Data = new { UserId = userId, Items = new List<object>(), GrandTotal = 0 }
                });
            }

            return Ok(new { Success = true, Data = result });
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto dto)
        {
            var result = await _mediator.Send(new AddToCartCommand(GetUserId(), dto));
            return Ok(new { Success = true, Message = "Item added to cart successfully." });
        }

        [HttpPut("update-quantity")]
        public async Task<IActionResult> UpdateQuantity([FromBody] UpdateCartItemQuantityDto dto)
        {
            var result = await _mediator.Send(new UpdateCartItemQuantityCommand(GetUserId(), dto));
            return Ok(new { Success = true, Message = "Cart item quantity updated." });
        }

        [HttpDelete("items/{cartItemId}")]
        public async Task<IActionResult> RemoveItem(Guid cartItemId)
        {
            var result = await _mediator.Send(new RemoveFromCartCommand(GetUserId(), cartItemId));
            return Ok(new { Success = true, Message = "Item removed from cart." });
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart()
        {
            var result = await _mediator.Send(new ClearCartCommand(GetUserId()));
            return Ok(new { Success = true, Message = "Cart cleared successfully." });
        }

        // 🔐 ব্যাকএন্ডে ব্যাকগ্রাউন্ড থেকে অটোমেটিক JWT Claims থেকে UserId নেওয়ার হেলপার
        private Guid GetUserId()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier)
                         ?? User.FindFirstValue("sub");

            if (!Guid.TryParse(userIdStr, out var userId))
            {
                throw new UnauthorizedAccessException("Invalid or missing User ID in token.");
            }

            return userId;
        }
    }
}

