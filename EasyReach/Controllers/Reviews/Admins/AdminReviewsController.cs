using EasyReach_Application.CQRS.Commands.Reviews.Admins;
using EasyReach_Application.CQRS.Querys.Reviews.Admins;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.Reviews.Admins
{
    [ApiController]
    [Route("api/admin/reviews")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Tags("Reviews")]
    public class AdminReviewsController(ISender mediator) : ControllerBase
    {
        /// <summary>
        /// পেন্ডিং (যা এখনও অপ্রুভ হয়নি) রিভিউগুলোর লিস্ট পাওয়ার জন্য
        /// </summary>
        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingReviews()
        {
            var result = await mediator.Send(new GetPendingReviewsQuery());
            return Ok(result);
        }

        /// <summary>
        /// কোনো রিভিউ Approve বা Reject/Unapprove করার জন্য
        /// </summary>
        [HttpPatch("{reviewId:guid}/approve")]
        public async Task<IActionResult> ApproveReview(Guid reviewId, [FromQuery] bool isApproved = true)
        {
            var result = await mediator.Send(new ApproveReviewCommand(reviewId, isApproved));
            return Ok(new { success = result, message = isApproved ? "Review approved successfully." : "Review status updated." });
        }

        /// <summary>
        /// কোনো অনুপযুক্ত রিভিউ ডিলিট করার জন্য
        /// </summary>
        [HttpDelete("{reviewId:guid}")]
        public async Task<IActionResult> DeleteReview(Guid reviewId)
        {
            var result = await mediator.Send(new DeleteReviewCommand(reviewId));
            return Ok(new { success = result, message = "Review deleted successfully." });
        }
    }
}
