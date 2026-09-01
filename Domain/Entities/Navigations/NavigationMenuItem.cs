using System;
using System.Collections.Generic;
using EasyReach_Domain.Common;
using EasyReach_Domain.Entities.Identities;

namespace EasyReach_Domain.Entities.Navigations
{
    // Navigation bar er dynamic menu item - Ghorerbazar er "Honey" (parent) ->
    // "Sundarban Honey", "Black Seed Honey" (sub-item) - ei rokom N-level
    // nesting support korte self-referencing (ParentMenuItemId) kora hoyeche,
    // thik Category entity er moto.

    // Shudhu SuperAdmin notun menu item (parent button) ba sub-item add/edit/
    // delete korte parbe - eta Application layer er authorization policy diye
    // enforce hobe (UserType.SuperAdmin check).

    // RequiredPermissionId (optional) diye existing RBAC (Role/Permission)
    // system er shathe link kora - jodi kono item shudhu nirdishto permission
    // thakle e dekhano lage (e.g. admin-panel er internal menu), customer-facing
    // public navbar item er jonno eta null thakbe.

    public class NavigationMenuItem : AuditableEntity
    {
        public string Label { get; set; } = string.Empty;
        public string? IconClass { get; set; }

        // React Router Path e.g. "/shop/honey" or "/about-us"
        public string? Route { get; set; }

        // React App dynamic page dynamic slug/ID
        public string? TargetType { get; set; } // e.g. "Category", "CustomPage", "ExternalLink"
        public string? TargetId { get; set; }   // Category Slug/ID বা Custom Page Slug

        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;

        // Self-referencing for N-level Submenus
        public Guid? ParentMenuItemId { get; set; }
        public NavigationMenuItem? ParentMenuItem { get; set; }
        public ICollection<NavigationMenuItem> ChildMenuItems { get; set; } = [];

        // Permission (Admin/Internal menu-r jonno, Public website-e null thakbe)
        public Guid? RequiredPermissionId { get; set; }
        public Permission? RequiredPermission { get; set; }
    }
}
