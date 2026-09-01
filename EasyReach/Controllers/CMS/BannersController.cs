using EasyReach_Application.CQRS.Commands.CMS;
using EasyReach_Application.CQRS.Querys.CMS;
using EasyReach_Application.DTOs.CMS;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.CMS
{
    [ApiController]
    [Route("api/[controller]")]
    public class BannersController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await mediator.Send(new GetAllBannersQuery()));

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id) => Ok(await mediator.Send(new GetBannerByIdQuery(id)));

        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Create([FromBody] CreateBannerDto dto) => Ok(await mediator.Send(new CreateBannerCommand(dto)));

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBannerDto dto)
        {
            dto.Id = id;
            return Ok(await mediator.Send(new UpdateBannerCommand(dto)));
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Delete(Guid id) => Ok(await mediator.Send(new DeleteBannerCommand(id)));
    }
}

