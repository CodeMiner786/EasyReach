using System;

namespace EasyReach_Application.DTOs.Identities
{
    /// <summary>
    /// Existing Role update korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class UpdateRoleDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsSystemRole { get; set; }
    }
}
