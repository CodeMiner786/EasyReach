using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.DTOs.Couriers
{
    public class CourierBookingResponseDto
    {
        public bool IsSuccess { get; set; }
        public string? ConsignmentId { get; set; }
        public string? TrackingCode { get; set; }
        public string? Message { get; set; }
    }
}
