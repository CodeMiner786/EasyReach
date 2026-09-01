using EasyReach_Application.SSLWireless;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Infrastructure.SSLWirelessSMS
{
    public class NoOpSmsService(ILogger<NoOpSmsService> logger) : ISmsService
    {
        private readonly ILogger<NoOpSmsService> _logger = logger;

        public Task SendAsync(string phoneNumber, string message, bool isUnicode = false, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("📱 [SMS Disabled] Would send to {Phone}: {Message}", phoneNumber, message);
            return Task.CompletedTask;
        }
    }
}
