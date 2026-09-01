namespace EasyReach_Application.DTOs.Identities.Auth
{
    /// <summary>
    /// Login kora user nijer purono password diye notun password set korbe
    /// (Forgot Password theke alada - eikhane user already logged-in).
    /// </summary>
    public class ChangePasswordDto
    {
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
