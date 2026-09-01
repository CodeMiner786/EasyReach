using EasyReach_Application.CQRS.Commands.Navigations;
using EasyReach_Application.CQRS.Querys.Navigations;
using EasyReach_Application.DTOs.Navigations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EasyReach.Controllers.Navigations.Admin
{
    [ApiController]
    [Route("api/admin/navigations")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Tags("Navigations")]
    public class AdminNavigationsController(ISender mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await mediator.Send(new GetAllNavigationMenuItemsQuery()));

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
            => Ok(await mediator.Send(new GetNavigationMenuItemByIdQuery(id)));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNavigationMenuItemDto dto)
        {
            // 🔐 Token থেকে লগইন করা Admin-এর User ID বের করা
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier)
                         ?? User.FindFirstValue("sub");

            if (!Guid.TryParse(userIdStr, out var userId) || userId == Guid.Empty)
            {
                return Unauthorized(new { success = false, message = "User ID not found in token." });
            }

            var result = await mediator.Send(new CreateNavigationMenuItemCommand(dto, userId));
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateNavigationMenuItemDto dto)
        {
            dto.Id = id;
            var result = await mediator.Send(new UpdateNavigationMenuItemCommand(dto));
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await mediator.Send(new DeleteNavigationMenuItemCommand(id));
            return Ok(new { success = result, message = "Navigation item deleted successfully." });
        }
    }
}
