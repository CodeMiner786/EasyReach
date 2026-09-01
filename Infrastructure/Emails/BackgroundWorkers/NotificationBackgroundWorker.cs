using EasyReach_Application.Emails;
using EasyReach_Application.SSLWireless;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EasyReach_Infrastructure.Emails.BackgroundWorkers
{
    public class NotificationBackgroundWorker(
        INotificationQueue queue,
        IServiceProvider serviceProvider,
        ILogger<NotificationBackgroundWorker> logger) : BackgroundService
    {
        private readonly INotificationQueue _queue = queue;
        private readonly IServiceProvider _serviceProvider = serviceProvider; // 👈 Scoped Service resolution-এর জন্য IServiceProvider ব্যবহার
        private readonly ILogger<NotificationBackgroundWorker> _logger = logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("🚀 Notification Background Worker Started...");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var notification = await _queue.DequeueAsync(stoppingToken);

                    // 🌟 প্রতিটি মেসেজ প্রসেস করার জন্য নতুন Scope তৈরি করা হচ্ছে
                    using var scope = _serviceProvider.CreateScope();
                    var smsService = scope.ServiceProvider.GetRequiredService<ISmsService>();
                    var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                    // ১. SMS পাঠানো
                    if (!string.IsNullOrWhiteSpace(notification.PhoneNumber))
                    {
                        await smsService.SendAsync(notification.PhoneNumber, notification.SmsBody, false, stoppingToken);
                    }

                    // ২. Email পাঠানো
                    if (!string.IsNullOrWhiteSpace(notification.Email))
                    {
                        await emailService.SendEmailAsync(notification.Email, notification.EmailSubject, notification.EmailBody, stoppingToken);
                    }
                }
                catch (OperationCanceledException)
                {
                    // App stopping
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing background notification.");
                }
            }
        }
    }
}

