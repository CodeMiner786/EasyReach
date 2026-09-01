using System;

namespace EasyReach_Application.DTOs.Identities.Auth
{
    /// <summary>
    /// Token refresh shofol hole notun AccessToken + notun RefreshToken
    /// (token rotation - purono RefreshToken shathe shathe revoke hoye jabe).
    /// </summary>
    public class RefreshTokenResponseDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public DateTime AccessTokenExpiresAt { get; set; }

        public string RefreshToken { get; set; } = string.Empty;
    }
}
