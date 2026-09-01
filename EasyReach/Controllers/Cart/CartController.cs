using EasyReach_Application.CQRS.Commands.Carts;
using EasyReach_Application.CQRS.Querys.Carts;
using EasyReach_Application.DTOs.Carts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EasyReach.Controllers.Cart
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CartController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        private Guid GetUserId() => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var result = await _mediator.Send(new GetCartByUserIdQuery(GetUserId()));
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto dto)
        {
            var result = await _mediator.Send(new AddToCartCommand(GetUserId(), dto));
            return Ok(new { Success = result, Message = "Item added to cart successfully." });
        }

        [HttpPut("update-quantity")]
        public async Task<IActionResult> UpdateQuantity([FromBody] UpdateCartItemQuantityDto dto)
        {
            var result = await _mediator.Send(new UpdateCartItemQuantityCommand(GetUserId(), dto));
            return Ok(new { Success = result, Message = "Cart item quantity updated." });
        }

        [HttpDelete("items/{cartItemId}")]
        public async Task<IActionResult> RemoveItem(Guid cartItemId)
        {
            var result = await _mediator.Send(new RemoveFromCartCommand(GetUserId(), cartItemId));
            return Ok(new { Success = result, Message = "Item removed from cart." });
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart()
        {
            var result = await _mediator.Send(new ClearCartCommand(GetUserId()));
            return Ok(new { Success = result, Message = "Cart cleared successfully." });
        }
    }
}
