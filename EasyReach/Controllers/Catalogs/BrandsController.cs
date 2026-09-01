using EasyReach_Application.CQRS.Commands.Brands;
using EasyReach_Application.CQRS.Querys.Brands;
using EasyReach_Application.DTOs.Catalogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.Catalogs
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("Brands")]
    public class BrandsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllBrandsQuery());
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Create([FromBody] CreateBrandDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await mediator.Send(new CreateBrandCommand(dto));
            return Ok(result);
        }
    }
}

