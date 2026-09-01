using EasyReach_Application.CQRS.Commands.Reviews;
using EasyReach_Application.CQRS.Querys.Reviews;
using EasyReach_Application.DTOs.Reviews;
using EasyReach_Domain.Common.Paginations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EasyReach.Controllers.Reviews
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductReviewsController(ISender mediator) : ControllerBase
    {
        private Guid CurrentUserId => Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        /// <summary>
        /// নির্দিষ্ট প্রোডাক্টের রিভিউ ও রেটিং সামারি পাওয়ার জন্য (Public)
        /// </summary>
        [HttpGet("product/{productId:guid}")]
        public async Task<IActionResult> GetProductReviews(Guid productId, [FromQuery] PaginationParams paginationParams)
        {
            var result = await mediator.Send(new GetProductReviewsQuery
            {
                ProductId = productId,
                PaginationParams = paginationParams
            });

            return Ok(result);
        }

        /// <summary>
        /// প্রোডাক্টের উপর রিভিউ যোগ করার জন্য (Authenticated Users)
        /// </summary>
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddReview([FromBody] AddReviewDto reviewDto)
        {
            try
            {
                var result = await mediator.Send(new AddProductReviewCommand(CurrentUserId, reviewDto));
                return Ok(new { success = result, message = "Review submitted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

