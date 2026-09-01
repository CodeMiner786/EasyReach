using EasyReach_Domain.Common;

namespace EasyReach_Domain.Entities.Identities
{
    // "Forgot Password" flow er jonno - user email diye reset request korle
    // ekta one-time token generate hoye email e pathano hobe. Token expire
    // (shadharonoto 15-30 min) ar IsUsed = true hole abar use kora jabe na -
    // eta security er jonno guruttopurno (RefreshToken theke alada rakha hoyeche
    // karon duitar lifecycle ar purpose completely different).
    public class PasswordResetToken : AuditableEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }

        public bool IsUsed { get; set; } = false;
        public DateTime? UsedAt { get; set; }

        public string? RequestedByIp { get; set; }
    }
}
