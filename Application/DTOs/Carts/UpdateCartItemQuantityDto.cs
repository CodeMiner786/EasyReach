using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.DTOs.Carts
{
    public class UpdateCartItemQuantityDto
    {
        public Guid CartItemId { get; set; }
        public int Quantity { get; set; }
    }
}
