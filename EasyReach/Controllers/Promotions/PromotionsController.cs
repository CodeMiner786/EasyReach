using EasyReach_Application.CQRS.Querys.Promotions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.Promotions
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionsController(ISender mediator) : ControllerBase
    {
        /// <summary>
        /// চলন্ত সব ডিসকাউন্টের তালিকা দেখার জন্য (Cached)
        /// </summary>
        [HttpGet("discounts/active")]
        public async Task<IActionResult> GetActiveDiscounts()
        {
            var result = await mediator.Send(new GetActiveDiscountsQuery());
            return Ok(result);
        }

        /// <summary>
        /// চলন্ত সব কম্বো প্যাকের তালিকা দেখার জন্য (Cached)
        /// </summary>
        [HttpGet("combos/active")]
        public async Task<IActionResult> GetActiveCombos()
        {
            var result = await mediator.Send(new GetActiveCombosQuery());
            return Ok(result);
        }

        /// <summary>
        /// নির্দিষ্ট কম্বো প্যাক ডিটেইলস দেখার জন্য (Cached)
        /// </summary>
        [HttpGet("combos/{id:guid}")]
        public async Task<IActionResult> GetComboById(Guid id)
        {
            var result = await mediator.Send(new GetComboByIdQuery(id));
            return result == null ? NotFound() : Ok(result);
        }
    }
}
