using EasyReach_Application.DTOs.CMS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.CMS.Pages
{
    public record CreatePageCommand(CreatePageDto Dto) : IRequest<Guid>;
    public record UpdatePageCommand(UpdatePageDto Dto) : IRequest<bool>;
    public record DeletePageCommand(Guid Id) : IRequest<bool>;
}
