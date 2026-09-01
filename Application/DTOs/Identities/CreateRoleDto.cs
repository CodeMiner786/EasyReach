using System;

namespace EasyReach_Application.DTOs.Identities
{
    /// <summary>
    /// Notun Role create korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class CreateRoleDto
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsSystemRole { get; set; }
    }
}
