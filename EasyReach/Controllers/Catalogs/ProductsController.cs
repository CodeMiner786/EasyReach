using EasyReach_Application.CQRS.Commands.Products;
using EasyReach_Application.CQRS.Commands.ProductVariants;
using EasyReach_Application.CQRS.Querys.Products;
using EasyReach_Application.CQRS.Querys.ProductVariants;
using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Domain.Common.Paginations;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace EasyReach.Controllers.Catalogs
{
    [ApiController]
    [Route("api/[controller]")]
    [Tags("Products")]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParams paginationParams, [FromQuery] string? searchTerm)
        {
            var query = new GetProductsQuery(paginationParams, searchTerm);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await mediator.Send(new GetProductByIdQuery(id));
            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Create([FromForm] CreateProductDto dto, IFormFile? imageFile)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (Request.Form.TryGetValue("variantsJson", out var variantsJsonValues))
            {
                var combinedList = new List<CreateProductVariantDto>();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                foreach (var jsonItem in variantsJsonValues)
                {
                    if (string.IsNullOrWhiteSpace(jsonItem)) continue;

                    try
                    {
                        var trimmed = jsonItem.Trim();
                        if (trimmed.StartsWith('['))
                        {
                            var list = JsonSerializer.Deserialize<List<CreateProductVariantDto>>(trimmed, options);
                            if (list != null) combinedList.AddRange(list);
                        }
                        else if (trimmed.StartsWith('{'))
                        {
                            var single = JsonSerializer.Deserialize<CreateProductVariantDto>(trimmed, options);
                            if (single != null) combinedList.Add(single);
                        }
                    }
                    catch
                    {
                        // Ignore individual parse error if any formatting mismatch occurs
                    }
                }

                if (combinedList.Count > 0)
                {
                    dto.Variants = combinedList;
                }
            }

            Stream? stream = null;
            string? fileName = null;
            string? contentType = null;

            if (imageFile != null)
            {
                stream = imageFile.OpenReadStream();
                fileName = imageFile.FileName;
                contentType = imageFile.ContentType;
            }

            var command = new CreateProductCommand(dto, GetUserId(), stream, fileName, contentType);
            var result = await mediator.Send(command);

            return Ok(new { Success = true, Message = "Product created successfully.", Data = result });
        }

        [HttpPost("variants")]
        [Authorize(Roles = "Admin,SuperAdmin")]
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

        private Guid GetUserId()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier)
                       ?? User.FindFirstValue("sub");

            return Guid.TryParse(userIdStr, out var userId) ? userId : Guid.Empty;
        }
    }
}

