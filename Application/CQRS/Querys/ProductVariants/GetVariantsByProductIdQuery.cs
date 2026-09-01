using EasyReach_Application.DTOs.Catalogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Querys.ProductVariants
{
    public record GetVariantsByProductIdQuery(Guid ProductId) : IRequest<IEnumerable<ProductVariantDto>>;
}
