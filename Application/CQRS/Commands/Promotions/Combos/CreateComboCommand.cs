using EasyReach_Application.DTOs.Promotions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.Promotions.Combos
{
    public record CreateComboCommand(CreateComboDto ComboDto) : IRequest<Guid>;
}
