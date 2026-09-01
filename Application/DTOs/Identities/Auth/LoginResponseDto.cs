using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Identities.Auth
{
    /// <summary>
    /// Login shofol hole ei shape e response jabe - client ei AccessToken
    /// diye protected API call korbe, RefreshToken diye expire howar por
    /// notun AccessToken nibe.
    /// </summary>
    public class LoginResponseDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserType UserType { get; set; }

        public string AccessToken { get; set; } = string.Empty;
        public DateTime AccessTokenExpiresAt { get; set; }

        public string RefreshToken { get; set; } = string.Empty;
    }
}
