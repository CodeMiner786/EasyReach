using EasyReach_Application.CourierService;
using EasyReach_Application.DTOs.Couriers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EasyReach_Infrastructure.CourierServices
{
    public class SteadfastCourierService(
        HttpClient httpClient,
        IConfiguration configuration,
        ILogger<SteadfastCourierService> logger) : ICourierService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IConfiguration _configuration = configuration;
        private readonly ILogger<SteadfastCourierService> _logger = logger;

        // 1. Delivery Ratio / Fraud Check Method
        public async Task<CourierRatioResponseDto> GetDeliveryRatioAsync(string phoneNumber)
        {
            try
            {
                var apiKey = _configuration["SteadfastSettings:ApiKey"];
                var secretKey = _configuration["SteadfastSettings:SecretKey"];
                var baseUrl = _configuration["SteadfastSettings:BaseUrl"];

                var requestUrl = $"{baseUrl}/fraud_check/{phoneNumber}";

                var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                request.Headers.Add("Api-Key", apiKey);
                request.Headers.Add("Secret-Key", secretKey);

                var response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return new CourierRatioResponseDto { PhoneNumber = phoneNumber, SuccessRate = 100 }; // Default Safe Fallback
                }

                var apiResult = await response.Content.ReadFromJsonAsync<SteadfastFraudResponse>();

                if (apiResult == null || apiResult.Data == null)
                {
                    return new CourierRatioResponseDto { PhoneNumber = phoneNumber, SuccessRate = 100 };
                }

                int delivered = apiResult.Data.TotalDelivered;
                int cancelled = apiResult.Data.TotalCancelled;
                int total = delivered + cancelled;

                double rate = total > 0 ? Math.Round(((double)delivered / total) * 100, 2) : 100.0;

                return new CourierRatioResponseDto
                {
                    PhoneNumber = phoneNumber,
                    TotalDelivered = delivered,
                    TotalCancelled = cancelled,
                    SuccessRate = rate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching delivery ratio for phone: {PhoneNumber}", phoneNumber);
                return new CourierRatioResponseDto { PhoneNumber = phoneNumber, SuccessRate = 100 };
            }
        }

        // 2. Parcel Booking Method (Create Order)
        public async Task<CourierBookingResponseDto> CreateOrderAsync(CourierOrderRequestDto requestDto)
        {
            try
            {
                var apiKey = _configuration["SteadfastSettings:ApiKey"];
                var secretKey = _configuration["SteadfastSettings:SecretKey"];
                var baseUrl = _configuration["SteadfastSettings:BaseUrl"];

                var requestUrl = $"{baseUrl}/create_order";

                var postData = new
                {
                    invoice = requestDto.Invoice,
                    recipient_name = requestDto.RecipientName,
                    recipient_phone = requestDto.RecipientPhone,
                    recipient_address = requestDto.RecipientAddress,
                    cod_amount = requestDto.CodAmount,
                    note = requestDto.Note ?? "Handle with care"
                };

                var request = new HttpRequestMessage(HttpMethod.Post, requestUrl)
                {
                    Content = JsonContent.Create(postData)
                };

                request.Headers.Add("Api-Key", apiKey);
                request.Headers.Add("Secret-Key", secretKey);

                var response = await _httpClient.SendAsync(request);
                var responseJson = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Steadfast API Failed with status {StatusCode}: {Response}", response.StatusCode, responseJson);
                    return new CourierBookingResponseDto { IsSuccess = false, Message = "Steadfast API request failed." };
                }

                using var doc = JsonDocument.Parse(responseJson);
                var root = doc.RootElement;

                int status = root.TryGetProperty("status", out var s) ? s.GetInt32() : 400;

                if (status == 200 && root.TryGetProperty("consignment", out var consignment))
                {
                    return new CourierBookingResponseDto
                    {
                        IsSuccess = true,
                        ConsignmentId = consignment.GetProperty("consignment_id").GetInt32().ToString(),
                        TrackingCode = consignment.GetProperty("tracking_code").GetString(),
                        Message = "Parcel booked successfully on Steadfast."
                    };
                }

                string message = root.TryGetProperty("message", out var msg) ? msg.GetString()! : "Booking failed.";
                return new CourierBookingResponseDto { IsSuccess = false, Message = message };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while booking Steadfast order for Invoice: {Invoice}", requestDto.Invoice);
                return new CourierBookingResponseDto { IsSuccess = false, Message = ex.Message };
            }
        }

        #region Private API Models
        private class SteadfastFraudResponse
        {
            [JsonPropertyName("status")]
            public int Status { get; set; }

            [JsonPropertyName("delivery_data")]
            public SteadfastDeliveryData? Data { get; set; }
        }

        private class SteadfastDeliveryData
        {
            [JsonPropertyName("total_delivered")]
            public int TotalDelivered { get; set; }

            [JsonPropertyName("total_cancelled")]
            public int TotalCancelled { get; set; }
        }
        #endregion
    }
}

