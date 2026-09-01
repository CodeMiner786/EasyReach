namespace EasyReach_Application.DTOs.Identities.Auth
{
    /// <summary>
    /// Notun Customer registration form er input. UserType/RoleId ekhane
    /// nei - shob shomoy UserType.Customer hisebe register hobe, Manager/Admin
    /// create shudhu SuperAdmin CreateApplicationUserDto diye korbe.
    /// </summary>
    public class RegisterDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
