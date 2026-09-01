using EasyReach_Application.DTOs.LandingPages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.LandingPages
{
    public record CreateLandingPageCommand(CreateLandingPageDto Dto) : IRequest<Guid>;
}
