using System;

namespace EasyReach_Application.DTOs.Navigations
{
    /// <summary>
    /// Notun NavigationMenuItem create korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class CreateNavigationMenuItemDto
    {
        public string Label { get; set; } = string.Empty;

        public string? IconClass { get; set; }

        public string? Route { get; set; }

        public string? TargetType { get; set; }

        public string? TargetId { get; set; }

        public Guid? ParentMenuItemId { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; } = true;

        public Guid? RequiredPermissionId { get; set; }
    }
}
