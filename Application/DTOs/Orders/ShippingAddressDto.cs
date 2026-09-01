using System;

namespace EasyReach_Application.DTOs.Orders
{
    /// <summary>
    /// ShippingAddress entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class ShippingAddressDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string AddressLine { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string District { get; set; } = string.Empty;

        public string? PostalCode { get; set; }

        public bool IsDefault { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
