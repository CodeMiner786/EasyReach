using System;
using EasyReach_Domain.Enums;

namespace EasyReach_Application.DTOs.Notifications
{
    /// <summary>
    /// Notification - system/business-logic theke generate hoy (Order placement, Cart operation etc.), tai shudhu Response DTO - kono Create/Update admin form nei.
    /// </summary>
    public class NotificationDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public NotificationType Type { get; set; }

        public bool IsRead { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
