using EasyReach_Application.DTOs.Promotions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Querys.Promotions
{
    public record GetComboByIdQuery(Guid Id) : IRequest<ComboDto?>;
}
