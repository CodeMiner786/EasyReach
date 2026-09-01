using EasyReach_Application.CQRS.Commands.Auth;
using EasyReach_Application.DTOs.Identities.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EasyReach.Controllers.Auth
{
    using EasyReach_Application.CQRS.Commands.Auth;
    using EasyReach_Application.DTOs.Identities.Auth;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    namespace EasyReach.Controllers.Auth
    {
        [ApiController]
        [Route("api/[controller]")]
        public class AuthController(ISender mediator) : ControllerBase
        {
            private string GetClientIp() => HttpContext.Connection.RemoteIpAddress?.ToString() ?? "0.0.0.0";

            [HttpPost("register")]
            public async Task<IActionResult> Register([FromBody] RegisterDto dto)
            {
                return Ok(await mediator.Send(new RegisterCommand(dto)));
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] LoginDto dto)
            {
                return Ok(await mediator.Send(new LoginCommand(dto, GetClientIp())));
            }

            [HttpPost("refresh-token")]
            public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto dto)
            {
                return Ok(await mediator.Send(new RefreshTokenCommand(dto, GetClientIp())));
            }

            [HttpPost("forgot-password")]
            public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
            {
                // Unnecessary assignment সরাতে 'var result =' বাদ দেওয়া হয়েছে
                await mediator.Send(new ForgotPasswordCommand(dto, GetClientIp()));
                return Ok(new { message = "If the email is registered, a password reset link has been sent." });
            }

            [HttpPost("reset-password")]
            public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
            {
                // Unnecessary assignment সরাতে 'var result =' বাদ দেওয়া হয়েছে
                await mediator.Send(new ResetPasswordCommand(dto));
                return Ok(new { message = "Password reset successfully." });
            }
        }
    }
}
