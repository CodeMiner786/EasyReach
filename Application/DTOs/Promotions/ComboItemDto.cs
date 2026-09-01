using System;

namespace EasyReach_Application.DTOs.Promotions
{
    /// <summary>
    /// ComboItem entity theke property niye banano - list/detail view dekhanor jonno.
    /// </summary>
    public class ComboItemDto
    {
        public Guid Id { get; set; }

        public Guid ComboId { get; set; }

        public Guid ProductVariantId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
