using EasyReach_Application.SSLWireless;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace EasyReach_Infrastructure.SSLWirelessSMS
{
    public class SslWirelessSmsService(
        IOptions<SslWirelessSettings> settings,
        IHttpClientFactory httpClientFactory,
        ILogger<SslWirelessSmsService> logger) : ISmsService
    {
        private readonly SslWirelessSettings _settings = settings.Value;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly ILogger<SslWirelessSmsService> _logger = logger;

        public async Task SendAsync(string phoneNumber, string message, bool isUnicode = false, CancellationToken cancellationToken = default)
        {
            if (!_settings.Enabled)
            {
                _logger.LogInformation("📱 [SMS Disabled] Would send to {Phone}: {Message}", phoneNumber, message);
                return;
            }

            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                _logger.LogWarning("Skipped sending SMS — recipient number was empty.");
                return;
            }

            try
            {
                var msisdn = NormalizeToMsisdn(phoneNumber);
                var body = isUnicode ? EncodeUnicode(message) : message;

                var payload = new
                {
                    api_token = _settings.ApiToken,
                    sid = _settings.Sid,
                    msisdn,
                    sms = body,
                    csms_id = Guid.NewGuid().ToString("N")[..20]
                };

                var json = JsonSerializer.Serialize(payload);
                using var content = new StringContent(json, Encoding.UTF8, "application/json");

                var client = _httpClientFactory.CreateClient("SslWirelessSmsClient");
                var response = await client.PostAsync($"{_settings.BaseUrl}/api/v3/send-sms", content, cancellationToken);
                var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("SSL Wireless rejected SMS to {Phone}. Status: {Status}. Response: {Body}",
                        phoneNumber, response.StatusCode, responseBody);
                    return;
                }

                using var doc = JsonDocument.Parse(responseBody);
                var status = doc.RootElement.TryGetProperty("status", out var statusEl) ? statusEl.GetString() : null;

                if (string.Equals(status, "SUCCESS", StringComparison.OrdinalIgnoreCase))
                {
                    _logger.LogInformation("SMS sent via SSL Wireless to {Phone}.", phoneNumber);
                }
                else
                {
                    _logger.LogWarning("SSL Wireless returned non-success status for {Phone}: {Body}", phoneNumber, responseBody);
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to send SMS via SSL Wireless to {Phone}.", phoneNumber);
            }
        }

        private static string NormalizeToMsisdn(string phoneNumber)
        {
            var digits = new string([.. phoneNumber.Where(char.IsDigit)]);

            if (digits.StartsWith("880")) return digits;
            if (digits.StartsWith('0')) return "88" + digits;
            return digits.StartsWith('1') ? "880" + digits : digits;
        }

        private static string EncodeUnicode(string message)
        {
            var bytes = Encoding.BigEndianUnicode.GetBytes(message);
            return Convert.ToHexString(bytes);
        }
    }
}



