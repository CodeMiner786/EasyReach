using System;

namespace EasyReach_Application.DTOs.Identities
{
    /// <summary>
    /// RefreshToken entity theke - admin/user er active session dekhanor jonno
    /// (jemon "Manage Devices" page). Actual Token value ekhane rakha hoyni -
    /// eta ekta security best practice, stored token kokhono API response e
    /// ferot pathano thik na.
    /// </summary>
    public class RefreshTokenDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public DateTime ExpiresAt { get; set; }
        public string? CreatedByIp { get; set; }

        public bool IsRevoked { get; set; }
        public DateTime? RevokedAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
