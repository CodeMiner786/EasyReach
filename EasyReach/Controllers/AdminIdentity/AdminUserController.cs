using EasyReach_Application.CQRS.Commands.AdminIdentity;
using EasyReach_Application.DTOs.Identities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.AdminIdentity
{
    [ApiController]
    [Route("api/admin/users")]
    [Tags("Admin Users")]
    public class AdminUserController(ISender mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await mediator.Send(new GetAllUsersQuery()));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateApplicationUserDto dto)
            => Ok(await mediator.Send(new CreateUserCommand(dto)));
    }
}
