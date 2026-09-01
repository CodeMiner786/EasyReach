using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Identities
{
    /// <summary>
    /// Permission entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class PermissionDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ModuleType Module { get; set; }

        public string? Description { get; set; }

        public bool CanView { get; set; }

        public bool CanCreate { get; set; }

        public bool CanEdit { get; set; }

        public bool CanDelete { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
