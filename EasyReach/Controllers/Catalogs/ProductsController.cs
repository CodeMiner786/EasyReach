using EasyReach_Application.CQRS.Commands.Products;
using EasyReach_Application.CQRS.Commands.ProductVariants;
using EasyReach_Application.CQRS.Querys.Products;
using EasyReach_Application.CQRS.Querys.ProductVariants;
using EasyReach_Application.DTOs.Catalogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.Catalogs
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("Products")]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await mediator.Send(new GetProductByIdQuery(id));
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // TODO: Extract actual logged-in user ID from Claims in real environment
            var userId = Guid.NewGuid();

            var result = await mediator.Send(new CreateProductCommand(dto, userId));
            return Ok(result);
        }

        [HttpPost("variants")]
        public async Task<IActionResult> CreateVariant([FromBody] CreateProductVariantDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await mediator.Send(new CreateProductVariantCommand(dto));
            return Ok(result);
        }

        [HttpGet("{productId:guid}/variants")]
        public async Task<IActionResult> GetVariantsByProductId(Guid productId)
        {
            var result = await mediator.Send(new GetVariantsByProductIdQuery(productId));
            return Ok(result);
        }
    }
}
