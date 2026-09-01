using EasyReach_Application.CQRS.Commands.CMS.Testimonials;
using EasyReach_Application.CQRS.Querys.CMS.Testimonials;
using EasyReach_Application.DTOs.CMS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.CMS.Testimonials
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("Testimonials")]
    public class TestimonialsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await mediator.Send(new GetAllTestimonialsQuery()));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTestimonialDto dto) => Ok(await mediator.Send(new CreateTestimonialCommand(dto)));

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTestimonialDto dto)
        {
            dto.Id = id;
            return Ok(await mediator.Send(new UpdateTestimonialCommand(dto)));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id) => Ok(await mediator.Send(new DeleteTestimonialCommand(id)));
    }
}
