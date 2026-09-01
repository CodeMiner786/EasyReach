using EasyReach_Application.Emails;
using EasyReach_Application.NotificationMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EasyReach_Infrastructure.Emails
{
    public class NotificationQueue : INotificationQueue
    {
        private readonly Channel<NotificationMessage> _channel;

        public NotificationQueue()
        {
            _channel = Channel.CreateUnbounded<NotificationMessage>(new UnboundedChannelOptions
            {
                SingleReader = true
            });
        }

        public async ValueTask QueueNotificationAsync(NotificationMessage notification, CancellationToken cancellationToken = default)
        {
            await _channel.Writer.WriteAsync(notification, cancellationToken);
        }

        public async ValueTask<NotificationMessage> DequeueAsync(CancellationToken cancellationToken)
        {
            return await _channel.Reader.ReadAsync(cancellationToken);
        }
    }
}
