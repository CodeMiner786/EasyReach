using EasyReach_Application.DTOs.Wishlists;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Querys.Wishlists
{
    public record GetWishlistByUserIdQuery(Guid UserId) : IRequest<WishlistResponseDto?>;
}
