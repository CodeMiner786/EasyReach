using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.Wishlists
{
    public record RemoveFromWishlistCommand(Guid UserId, Guid ProductId) : IRequest<bool>;
}
