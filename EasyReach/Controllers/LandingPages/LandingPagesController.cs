using EasyReach_Application.CQRS.Querys.LandingPages;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.LandingPages
{
    [ApiController]
    [Route("api/[controller]")]
    public class LandingPagesController(ISender mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPublishedPages()
        {
            var result = await mediator.Send(new GetPublishedLandingPagesQuery());
            return Ok(result);
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetBySlug(string slug)
        {
            var result = await mediator.Send(new GetLandingPageBySlugQuery(slug));
            return result == null ? NotFound() : Ok(result);
        }
    }
}
