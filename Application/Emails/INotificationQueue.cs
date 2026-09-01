using EasyReach_Application.NotificationMessages;

namespace EasyReach_Application.Emails
{
    public interface INotificationQueue
    {
        ValueTask QueueNotificationAsync(NotificationMessage notification, CancellationToken cancellationToken = default);
        ValueTask<NotificationMessage> DequeueAsync(CancellationToken cancellationToken);
    }
}
