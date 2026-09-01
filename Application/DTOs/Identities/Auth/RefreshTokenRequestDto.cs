namespace EasyReach_Application.DTOs.Identities.Auth
{
    /// <summary>
    /// AccessToken expire hoye gele client ei RefreshToken pathaye
    /// notun AccessToken chaibe.
    /// </summary>
    public class RefreshTokenRequestDto
    {
        public string RefreshToken { get; set; } = string.Empty;
    }
}
