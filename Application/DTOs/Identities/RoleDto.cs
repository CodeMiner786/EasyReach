using System;

namespace EasyReach_Application.DTOs.Identities
{
    /// <summary>
    /// Role entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class RoleDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public bool IsSystemRole { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
