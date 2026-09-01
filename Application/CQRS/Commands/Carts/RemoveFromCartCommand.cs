using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.Carts
{
    public record RemoveFromCartCommand(Guid UserId, Guid CartItemId) : IRequest<bool>;
    public record ClearCartCommand(Guid UserId) : IRequest<bool>;
}
