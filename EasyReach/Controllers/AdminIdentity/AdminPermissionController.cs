using EasyReach_Application.CQRS.Commands.AdminIdentity;
using EasyReach_Application.DTOs.Identities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.AdminIdentity
{
    [ApiController]
    [Route("api/admin/permissions")]
    [Tags("Admin Permissions")]
    public class AdminPermissionController(ISender mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await mediator.Send(new GetAllPermissionsQuery()));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePermissionDto dto)
            => Ok(await mediator.Send(new CreatePermissionCommand(dto)));
    }
}

