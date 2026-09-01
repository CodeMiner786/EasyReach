using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Identities
{
    /// <summary>
    /// Existing ApplicationUser update korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class UpdateApplicationUserDto
    {
        public Guid Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string? ProfileImageUrl { get; set; }

        public UserType UserType { get; set; }

        public bool IsActive { get; set; }

        public Guid? RoleId { get; set; }
    }
}
