using EasyReach_Application.CQRS.Commands.Cataloges;
using EasyReach_Application.CQRS.Querys.Cataloges;
using EasyReach_Application.DTOs.Catalogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.Catalogs
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("Categories")]
    public class CategoriesController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllCategoriesQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await mediator.Send(new CreateCategoryCommand(dto));
            return Ok(result);
        }
    }
}
