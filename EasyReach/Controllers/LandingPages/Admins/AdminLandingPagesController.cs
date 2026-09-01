using EasyReach_Application.CQRS.Commands.LandingPages;
using EasyReach_Application.DTOs.LandingPages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.LandingPages.Admins
{
    [ApiController]
    [Route("api/admin/landing-pages")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Tags("LandingPages")]
    public class AdminLandingPagesController(ISender mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLandingPageDto dto)
        {
            var id = await mediator.Send(new CreateLandingPageCommand(dto));
            return Ok(new { id, message = "Landing page created successfully." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLandingPageDto dto)
        {
            var result = await mediator.Send(new UpdateLandingPageCommand(dto));
            return Ok(new { success = result, message = "Landing page updated successfully." });
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await mediator.Send(new DeleteLandingPageCommand(id));
            return Ok(new { success = result, message = "Landing page deleted successfully." });
        }
    }
}
