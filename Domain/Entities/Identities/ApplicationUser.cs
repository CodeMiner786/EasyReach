using EasyReach_Domain.Common;
using EasyReach_Domain.Entities.Carts;
using EasyReach_Domain.Entities.Orders;
using EasyReach_Domain.Entities.Wishlists;
using EasyReach_Domain.Enums;

namespace EasyReach_Domain.Entities.Identities
{
    // Customer, Manager, Admin, SuperAdmin - shobar jonno ekta single user table.
    // UserType diye alada kora hoy. Manager/Admin hole RoleId thakbe (permission set).
    public class ApplicationUser : AuditableEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public string? ProfileImageUrl { get; set; }

        public UserType UserType { get; set; } = UserType.Customer;
        public bool IsActive { get; set; } = true;
        public DateTime? LastLoginAt { get; set; }

        // Manager/Admin hole RoleId set thakbe - customer er jonno null
        public Guid? RoleId { get; set; }
        public Role? Role { get; set; }

        // Navigation properties
        public Cart? Cart { get; set; }
        public Wishlist? Wishlist { get; set; }
        public ICollection<Order> Orders { get; set; } = [];
        public ICollection<AdminActivityLog> ActivityLogs { get; set; } = [];
        public ICollection<RefreshToken> RefreshTokens { get; set; } = [];
        public ICollection<PasswordResetToken> PasswordResetTokens { get; set; } = [];
    }
}
