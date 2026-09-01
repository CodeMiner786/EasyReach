using EasyReach_Application.CQRS.Commands.CMS.Faqs;
using EasyReach_Application.CQRS.Querys.CMS.Faqs;
using EasyReach_Application.DTOs.CMS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.CMS.Faqs
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("FAQs")]
    public class FaqItemsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await mediator.Send(new GetAllFaqItemsQuery()));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFaqItemDto dto) => Ok(await mediator.Send(new CreateFaqItemCommand(dto)));

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateFaqItemDto dto)
        {
            dto.Id = id;
            return Ok(await mediator.Send(new UpdateFaqItemCommand(dto)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id) => Ok(await mediator.Send(new DeleteFaqItemCommand(id)));
    }
}
