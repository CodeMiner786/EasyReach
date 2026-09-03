using EasyReach_Application.CQRS.Commands.CMS;
using EasyReach_Application.CQRS.Querys.CMS;
using EasyReach_Application.DTOs.CMS;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Create([FromForm] CreateBannerDto dto, IFormFile? imageFile)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Stream? stream = null;
            string? fileName = null;
            string? contentType = null;

            if (imageFile != null)
            {
                stream = imageFile.OpenReadStream();
                fileName = imageFile.FileName;
                contentType = imageFile.ContentType;
            }

            var command = new CreateBannerCommand(dto, stream, fileName, contentType);
            var bannerId = await mediator.Send(command);

            return Ok(new { Success = true, Message = "Banner created successfully.", Data = bannerId });
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Update(Guid id, [FromForm] UpdateBannerDto dto, IFormFile? imageFile)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            dto.Id = id;

            Stream? stream = null;
            string? fileName = null;
            string? contentType = null;

            if (imageFile != null)
            {
                stream = imageFile.OpenReadStream();
                fileName = imageFile.FileName;
                contentType = imageFile.ContentType;
            }

            var command = new UpdateBannerCommand(dto, stream, fileName, contentType);
            var result = await mediator.Send(command);

            return Ok(new { Success = true, Message = "Banner updated successfully.", Data = result });
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> Delete(Guid id) => Ok(await mediator.Send(new DeleteBannerCommand(id)));
    }
}

