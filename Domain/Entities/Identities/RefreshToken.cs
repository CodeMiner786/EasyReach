using EasyReach_Domain.Common;

namespace EasyReach_Domain.Entities.Identities
{
    // JWT access token expire hoye gele, ei RefreshToken diye user re-login
    // na kore notun access token nite parbe. Login korar shomoy ekta RefreshToken
    // generate hobe, login/logout/token-refresh - shob shomoy ei entity use hobe.
    //
    // Ekta user er multiple device e login thakle each device er jonno alada
    // RefreshToken row thakbe (tai UserId - Token relation ekta 1-to-many).
    public class RefreshToken : AuditableEntity
    {
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }

        // Security audit er jonno - kon IP theke token ta issue hoyeche
        public string? CreatedByIp { get; set; }

        // Token revoke (logout/security issue) hole ei field gulo set hobe
        public bool IsRevoked { get; set; } = false;
        public DateTime? RevokedAt { get; set; }
        public string? RevokedByIp { get; set; }

        // Token rotation - purono token diye notun token issue hole
        // notun tokenta ekhane link kora thake (audit trail)
        public string? ReplacedByToken { get; set; }
    }
}
