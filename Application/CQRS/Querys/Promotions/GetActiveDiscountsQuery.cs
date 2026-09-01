using EasyReach_Application.DTOs.Promotions;
using EasyReach_Domain.Common.Paginations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Querys.Promotions;
public class GetActiveDiscountsQuery : IRequest<PagedResult<DiscountDto>>
{
    public PaginationParams PaginationParams { get; set; } = new();
}
