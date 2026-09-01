using EasyReach_Application.DTOs.Catalogs;
using EasyReach_Domain.Common.Paginations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Querys.Brands
{
    public class GetAllBrandsQuery : IRequest<PagedResult<BrandDto>>
    {
        public PaginationParams PaginationParams { get; set; } = new();
    }
}
