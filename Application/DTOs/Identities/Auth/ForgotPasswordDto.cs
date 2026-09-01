namespace EasyReach_Application.DTOs.Identities.Auth
{
    /// <summary>
    /// "Forgot Password" - user shudhu email dibe, backend shei email e
    /// PasswordResetToken shoho reset link pathabe.
    /// </summary>
    public class ForgotPasswordDto
    {
        public string Email { get; set; } = string.Empty;
    }
}
