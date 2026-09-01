using EasyReach_Application.DTOs.Carts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.Carts
{
    public record UpdateCartItemQuantityCommand(Guid UserId, UpdateCartItemQuantityDto Dto) : IRequest<bool>;
}

