using EasyReach_Application.CQRS.Commands.Promotions;
using EasyReach_Application.CQRS.Commands.Promotions.Combos;
using EasyReach_Application.DTOs.Promotions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.Promotions.AdminPromotions
{
    [ApiController]
    [Route("api/admin/promotions")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Tags("Promotions")]
    public class AdminPromotionsController(ISender mediator) : ControllerBase
    {
        // ================= Disounts =================
        [HttpPost("discounts")]
        public async Task<IActionResult> CreateDiscount([FromBody] CreateDiscountDto dto)
        {
            var id = await mediator.Send(new CreateDiscountCommand(dto));
            return Ok(new { id, message = "Discount offer created successfully." });
        }

        [HttpPut("discounts")]
        public async Task<IActionResult> UpdateDiscount([FromBody] UpdateDiscountDto dto)
        {
            var result = await mediator.Send(new UpdateDiscountCommand(dto));
            return Ok(new { success = result, message = "Discount offer updated successfully." });
        }

        [HttpDelete("discounts/{id:guid}")]
        public async Task<IActionResult> DeleteDiscount(Guid id)
        {
            var result = await mediator.Send(new DeleteDiscountCommand(id));
            return Ok(new { success = result, message = "Discount offer deleted successfully." });
        }

        // ================= Combos =================
        [HttpPost("combos")]
        public async Task<IActionResult> CreateCombo([FromBody] CreateComboDto dto)
        {
            var id = await mediator.Send(new CreateComboCommand(dto));
            return Ok(new { id, message = "Combo deal created successfully." });
        }

        [HttpPut("combos")]
        public async Task<IActionResult> UpdateCombo([FromBody] UpdateComboDto dto)
        {
            var result = await mediator.Send(new UpdateComboCommand(dto));
            return Ok(new { success = result, message = "Combo deal updated successfully." });
        }

        [HttpDelete("combos/{id:guid}")]
        public async Task<IActionResult> DeleteCombo(Guid id)
        {
            var result = await mediator.Send(new DeleteComboCommand(id));
            return Ok(new { success = result, message = "Combo deal deleted successfully." });
        }
    }
}
