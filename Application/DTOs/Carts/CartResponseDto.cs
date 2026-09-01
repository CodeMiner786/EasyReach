using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.DTOs.Carts
{
    public class CartResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<CartItemResponseDto> Items { get; set; } = [];
        public decimal TotalAmount { get; set; }
    }
}
