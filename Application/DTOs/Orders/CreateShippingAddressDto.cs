using System;

namespace EasyReach_Application.DTOs.Orders
{
    /// <summary>
    /// Notun ShippingAddress create korar shomoy input hisebe ei DTO use hobe.
    /// </summary>
    public class CreateShippingAddressDto
    {
        public Guid UserId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string AddressLine { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string District { get; set; } = string.Empty;

        public string? PostalCode { get; set; }

        public bool IsDefault { get; set; }
    }
}
