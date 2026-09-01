using EasyReach_Application.CQRS.Commands.Wishlists;
using EasyReach_Application.CQRS.Querys.Wishlists;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EasyReach.Controllers.Wishlists
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // 🔒 শুধুমাত্র অথেনটিকেটেড ইউজারদের অনুমতি দেওয়া হলো
    public class WishlistController(ISender mediator) : ControllerBase
    {
        private Guid CurrentUserId => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        /// <summary>
        /// চলতি ইউজারের উইশলিস্ট গেট করা (Redis Cache সহ)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetWishlist()
        {
            var result = await mediator.Send(new GetWishlistByUserIdQuery(CurrentUserId));
            return Ok(result);
        }

        /// <summary>
        /// উইশলিস্টে প্রোডাক্ট যোগ করার জন্য
        /// </summary>
        [HttpPost("add/{productId:guid}")]
        public async Task<IActionResult> AddToWishlist(Guid productId)
        {
            var result = await mediator.Send(new AddToWishlistCommand(CurrentUserId, productId));
            return Ok(new { success = result, message = "Product added to wishlist successfully." });
        }

        /// <summary>
        /// উইশলিস্ট থেকে প্রোডাক্ট রিমুভ করার জন্য
        /// </summary>
        [HttpDelete("remove/{productId:guid}")]
        public async Task<IActionResult> RemoveFromWishlist(Guid productId)
        {
            var result = await mediator.Send(new RemoveFromWishlistCommand(CurrentUserId, productId));
            return Ok(new { success = result, message = "Product removed from wishlist." });
        }
    }
}

