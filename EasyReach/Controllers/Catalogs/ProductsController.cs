using EasyReach_Application.CQRS.Commands.Products;
using EasyReach_Application.CQRS.Commands.ProductVariants;
using EasyReach_Application.CQRS.Querys.Products;
using EasyReach_Application.CQRS.Querys.ProductVariants;
using EasyReach_Application.DTOs.Catalogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [Authorize(Roles = "Admin,SuperAdmin")] // 🔐 শুধু Admin/SuperAdmin প্রোডাক্ট ক্রিয়েট করতে পারবে
        public async Task<IActionResult> Create([FromForm] CreateProductDto dto, IFormFile? imageFile)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Stream? stream = null;
            string? fileName = null;
            string? contentType = null;

            // 📷 ফাইল আপলোড করা থাকলে Stream তৈরি
            if (imageFile != null)
            {
                stream = imageFile.OpenReadStream();
                fileName = imageFile.FileName;
                contentType = imageFile.ContentType;
            }

            // 🚀 Command-এ Dto এবং Image Data পাস করা হচ্ছে
            var command = new CreateProductCommand(dto, stream, fileName, contentType);
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

        // 🔐 টোকেন থেকে Logged-in User-এর ID নেওয়ার প্রাইভেট হেলপার
        private Guid GetUserId()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier)
                         ?? User.FindFirstValue("sub");

            return Guid.TryParse(userIdStr, out var userId) ? userId : Guid.Empty;
        }
    }
}
