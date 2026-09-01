using EasyReach_Application.DTOs.Identities.Auth;
using MediatR;

namespace EasyReach_Application.CQRS.Commands.Auth
{
    public record RegisterCommand(RegisterDto RegisterDto) : IRequest<LoginResponseDto>;

    public record LoginCommand(LoginDto LoginDto, string IpAddress) : IRequest<LoginResponseDto>;

    public record RefreshTokenCommand(RefreshTokenRequestDto RefreshTokenDto, string IpAddress) : IRequest<RefreshTokenResponseDto>;

    public record RevokeTokenCommand(string RefreshToken, string IpAddress) : IRequest<bool>;

    public record ForgotPasswordCommand(ForgotPasswordDto ForgotPasswordDto, string IpAddress) : IRequest<bool>;

    public record ResetPasswordCommand(ResetPasswordDto ResetPasswordDto) : IRequest<bool>;

    public record ChangePasswordCommand(Guid UserId, ChangePasswordDto ChangePasswordDto) : IRequest<bool>;

}
