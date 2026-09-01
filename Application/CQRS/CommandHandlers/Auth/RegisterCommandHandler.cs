using AutoMapper;
using EasyReach_Application.CQRS.Commands.Auth;
using EasyReach_Application.DTOs.Identities.Auth;
using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Application.Interfaces.Repositories.HashPasswords;
using EasyReach_Domain.Entities.Identities;
using EasyReach_Domain.Enums;
using MediatR;

namespace EasyReach_Application.CQRS.CommandHandlers.Auth
{
    public class RegisterCommandHandler(
        IApplicationUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IMapper mapper) : IRequestHandler<RegisterCommand, LoginResponseDto>
    {
        public async Task<LoginResponseDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (request.RegisterDto.Password != request.RegisterDto.ConfirmPassword)
                throw new InvalidOperationException("Passwords do not match.");

            bool isUnique = await userRepository.IsEmailUniqueAsync(request.RegisterDto.Email);
            if (!isUnique)
                throw new InvalidOperationException("Email is already registered.");

            var user = mapper.Map<ApplicationUser>(request.RegisterDto);
            user.UserType = UserType.Customer;
            user.PasswordHash = passwordHasher.HashPassword(request.RegisterDto.Password);

            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();

            return new LoginResponseDto
            {
                UserId = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                UserType = user.UserType,
                AccessToken = "SAMPLE_ACCESS_TOKEN",
                AccessTokenExpiresAt = DateTime.UtcNow.AddHours(2),
                RefreshToken = "SAMPLE_REFRESH_TOKEN"
            };
        }
    }

    public class LoginCommandHandler(
        IApplicationUserRepository userRepository,
        IRefreshTokenRepository refreshTokenRepository,
        IPasswordHasher passwordHasher) : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        public async Task<LoginResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByEmailAsync(request.LoginDto.Email)
                ?? throw new InvalidOperationException("Invalid credentials.");

            if (!passwordHasher.VerifyPassword(request.LoginDto.Password, user.PasswordHash))
                throw new InvalidOperationException("Invalid credentials.");

            if (!user.IsActive)
                throw new InvalidOperationException("User account is disabled.");

            user.LastLoginAt = DateTime.UtcNow;
            userRepository.Update(user);

            var refreshToken = new RefreshToken
            {
                UserId = user.Id,
                Token = Guid.NewGuid().ToString("N"),
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                CreatedByIp = request.IpAddress
            };

            await refreshTokenRepository.AddAsync(refreshToken);
            await userRepository.SaveChangesAsync();

            return new LoginResponseDto
            {
                UserId = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                UserType = user.UserType,
                AccessToken = "JWT_ACCESS_TOKEN",
                AccessTokenExpiresAt = DateTime.UtcNow.AddHours(2),
                RefreshToken = refreshToken.Token
            };
        }
    }

    public class RefreshTokenCommandHandler(
        IRefreshTokenRepository refreshTokenRepository) : IRequestHandler<RefreshTokenCommand, RefreshTokenResponseDto>
    {
        public async Task<RefreshTokenResponseDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var existingToken = await refreshTokenRepository.GetByTokenAsync(request.RefreshTokenDto.RefreshToken)
                ?? throw new InvalidOperationException("Invalid Refresh Token.");

            if (existingToken.IsRevoked || existingToken.ExpiresAt <= DateTime.UtcNow)
                throw new InvalidOperationException("Expired or Revoked Refresh Token.");

            existingToken.IsRevoked = true;
            existingToken.RevokedAt = DateTime.UtcNow;
            existingToken.RevokedByIp = request.IpAddress;

            string newRefreshTokenStr = Guid.NewGuid().ToString("N");
            existingToken.ReplacedByToken = newRefreshTokenStr;

            var newRefreshToken = new RefreshToken
            {
                UserId = existingToken.UserId,
                Token = newRefreshTokenStr,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                CreatedByIp = request.IpAddress
            };

            await refreshTokenRepository.AddAsync(newRefreshToken);
            await refreshTokenRepository.SaveChangesAsync();

            return new RefreshTokenResponseDto
            {
                AccessToken = "NEW_JWT_ACCESS_TOKEN",
                AccessTokenExpiresAt = DateTime.UtcNow.AddHours(2),
                RefreshToken = newRefreshTokenStr
            };
        }
    }

    public class ForgotPasswordCommandHandler(
        IApplicationUserRepository userRepository,
        IPasswordResetTokenRepository resetTokenRepository) : IRequestHandler<ForgotPasswordCommand, bool>
    {
        public async Task<bool> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetByEmailAsync(request.ForgotPasswordDto.Email);
            if (user == null) return true;

            var resetToken = new PasswordResetToken
            {
                UserId = user.Id,
                Token = Guid.NewGuid().ToString("N"),
                ExpiresAt = DateTime.UtcNow.AddMinutes(30),
                RequestedByIp = request.IpAddress
            };

            await resetTokenRepository.AddAsync(resetToken);
            await resetTokenRepository.SaveChangesAsync();

            return true;
        }
    }

    public class ResetPasswordCommandHandler(
        IPasswordResetTokenRepository resetTokenRepository,
        IApplicationUserRepository userRepository,
        IPasswordHasher passwordHasher) : IRequestHandler<ResetPasswordCommand, bool>
    {
        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            if (request.ResetPasswordDto.NewPassword != request.ResetPasswordDto.ConfirmPassword)
                throw new InvalidOperationException("Passwords do not match.");

            var tokenEntity = await resetTokenRepository.GetValidTokenAsync(request.ResetPasswordDto.Token)
                ?? throw new InvalidOperationException("Invalid or expired reset token.");

            var user = await userRepository.GetByIdAsync(tokenEntity.UserId)
                ?? throw new InvalidOperationException("User not found.");

            user.PasswordHash = passwordHasher.HashPassword(request.ResetPasswordDto.NewPassword);
            tokenEntity.IsUsed = true;
            tokenEntity.UsedAt = DateTime.UtcNow;

            userRepository.Update(user);
            await userRepository.SaveChangesAsync();

            return true;
        }
    }
}
