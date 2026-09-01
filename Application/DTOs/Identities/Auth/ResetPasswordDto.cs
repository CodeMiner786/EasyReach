namespace EasyReach_Application.DTOs.Identities.Auth
{
    /// <summary>
    /// Email er link theke ashar por user notun password set korbe -
    /// Token ta PasswordResetToken.Token er shathe match kore validate hobe.
    /// </summary>
    public class ResetPasswordDto
    {
        public string Token { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
