using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.Promotions
{
    public record DeleteDiscountCommand(Guid Id) : IRequest<bool>;
}
