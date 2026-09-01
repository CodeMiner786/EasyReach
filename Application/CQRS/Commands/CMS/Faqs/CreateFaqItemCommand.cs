using EasyReach_Application.DTOs.CMS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.CMS.Faqs
{
    public record CreateFaqItemCommand(CreateFaqItemDto Dto) : IRequest<Guid>;
    public record UpdateFaqItemCommand(UpdateFaqItemDto Dto) : IRequest<bool>;
    public record DeleteFaqItemCommand(Guid Id) : IRequest<bool>;
}
