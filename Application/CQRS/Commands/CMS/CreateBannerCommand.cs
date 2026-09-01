using EasyReach_Application.DTOs.CMS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.CMS
{
    public record CreateBannerCommand(CreateBannerDto Dto) : IRequest<Guid>;
    public record UpdateBannerCommand(UpdateBannerDto Dto) : IRequest<bool>;
    public record DeleteBannerCommand(Guid Id) : IRequest<bool>;
}
