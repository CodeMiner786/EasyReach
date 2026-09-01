using EasyReach_Application.Interfaces.Repositories;
using EasyReach_Domain.Entities.Notifications;
using EasyReach_Infrastructure.Persistence;

namespace EasyReach_Infrastructure.Repositories
{
    public class NotificationRepository(ApplicationDbContext context) : GenericRepository<Notification>(context), INotificationRepository
    {
    }
}


// INotificationRepository er implementation. GenericRepository&lt;Notification&gt;
// theke shob CRUD method already paay - ekhane shudhu constructor,
// ar bhobishyot e Notification-specific custom method thakle shegulo likha hobe.

