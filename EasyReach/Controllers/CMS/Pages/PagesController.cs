using EasyReach_Application.CQRS.Commands.CMS.Pages;
using EasyReach_Application.CQRS.Querys.CMS.Pages;
using EasyReach_Application.DTOs.CMS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.CMS.Pages
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("Pages")]
    public class PagesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await mediator.Send(new GetAllPagesQuery()));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePageDto dto) => Ok(await mediator.Send(new CreatePageCommand(dto)));

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePageDto dto)
        {
            dto.Id = id;
            return Ok(await mediator.Send(new UpdatePageCommand(dto)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id) => Ok(await mediator.Send(new DeletePageCommand(id)));

        [HttpGet("slug/{slug}")]
        public async Task<IActionResult> GetBySlug(string slug)
        => Ok(await mediator.Send(new GetPageBySlugQuery(slug)));
    }
}
