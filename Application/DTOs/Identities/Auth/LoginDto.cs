namespace EasyReach_Application.DTOs.Identities.Auth
{
    /// <summary>
    /// Login form er input - Customer ba Admin/Manager shobar jonno common.
    /// </summary>
    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
