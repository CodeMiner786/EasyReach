using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.DTOs.Wishlists
{
    public class WishlistResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<WishlistItemResponseDto> Items { get; set; } = [];
    }
}
