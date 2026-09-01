using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Identities
{
    /// <summary>
    /// Notun ApplicationUser create korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class CreateApplicationUserDto
    {
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string? ProfileImageUrl { get; set; }

        public UserType UserType { get; set; }

        public bool IsActive { get; set; }

        public Guid? RoleId { get; set; }

        public string Password { get; set; } = string.Empty;
    }
}
