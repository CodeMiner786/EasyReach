using System;

namespace EasyReach_Application.DTOs.Identities
{
    /// <summary>
    /// PasswordResetToken entity theke - admin audit/log view er jonno.
    /// Actual Token value ekhane rakha hoyni (security best practice).
    /// </summary>
    public class PasswordResetTokenDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
        public DateTime? UsedAt { get; set; }
        public string? RequestedByIp { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
