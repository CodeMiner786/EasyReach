using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Dashboards
{
    /// <summary>
    /// AdminActivityLog entity theke - dashboard e "kon manager ekhon
    /// ki korlo" emon ekta live activity feed dekhanor jonno.
    /// </summary>
    public class RecentActivityDto
    {
        public string UserFullName { get; set; } = string.Empty;
        public ActivityActionType ActionType { get; set; }
        public ModuleType Module { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
