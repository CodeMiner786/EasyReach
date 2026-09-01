using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Identities
{
    /// <summary>
    /// Existing Permission update korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class UpdatePermissionDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ModuleType Module { get; set; }

        public string? Description { get; set; }

        public bool CanView { get; set; }

        public bool CanCreate { get; set; }

        public bool CanEdit { get; set; }

        public bool CanDelete { get; set; }
    }
}
