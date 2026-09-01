using AutoMapper;
using EasyReach_Application.DTOs.Notifications;
using EasyReach_Domain.Entities.Notifications;

namespace EasyReach_Application.Mappings.Notifications
{
    /// <summary>
    /// Notification entity theke NotificationDto te shudhu Response mapping -
    /// eta system/business-logic theke generate hoy, tai kono Create/Update
    /// mapping nei (matches the Create/Update DTO policy for this entity).
    /// </summary>
    public class NotificationMappingProfile : Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<Notification, NotificationDto>();
        }
    }
}
