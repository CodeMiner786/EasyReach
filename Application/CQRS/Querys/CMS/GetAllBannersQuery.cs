using EasyReach_Application.DTOs.CMS;
using EasyReach_Domain.Common.Paginations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Querys.CMS
{
    public class GetAllBannersQuery : IRequest<PagedResult<BannerDto>>
    {
        public PaginationParams PaginationParams { get; set; } = new();
    }

    public record GetBannerByIdQuery(Guid Id) : IRequest<BannerDto?>;
    public record GetActiveBannersQuery() : IRequest<List<BannerDto>>;
}
