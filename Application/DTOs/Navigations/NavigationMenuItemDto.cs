using System;

namespace EasyReach_Application.DTOs.Navigations
{
    /// <summary>
    /// NavigationMenuItem entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class NavigationMenuItemDto
    {
        public Guid Id { get; set; }

        public string Label { get; set; } = string.Empty;

        public string? IconClass { get; set; }

        public string? Route { get; set; }

        public string? TargetType { get; set; }

        public string? TargetId { get; set; }

        public Guid? ParentMenuItemId { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public Guid? RequiredPermissionId { get; set; }

        public DateTime CreatedAt { get; set; }

        // Optional: Tree view rendering helper for frontend
        public List<NavigationMenuItemDto> Children { get; set; } = [];
    }
}
