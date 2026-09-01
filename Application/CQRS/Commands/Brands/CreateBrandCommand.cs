using EasyReach_Application.DTOs.Catalogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.Brands
{
    public record CreateBrandCommand(CreateBrandDto Dto) : IRequest<BrandDto>;
}
