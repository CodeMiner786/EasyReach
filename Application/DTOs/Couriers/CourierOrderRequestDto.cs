using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.DTOs.Couriers
{
    public class CourierOrderRequestDto
    {
        public string Invoice { get; set; } = string.Empty;
        public string RecipientName { get; set; } = string.Empty;
        public string RecipientPhone { get; set; } = string.Empty;
        public string RecipientAddress { get; set; } = string.Empty;
        public decimal CodAmount { get; set; }
        public string? Note { get; set; }
    }
}
