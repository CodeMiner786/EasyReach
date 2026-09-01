using EasyReach_Application.DTOs.Catalogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Commands.Products
{
    public record CreateProductCommand(
    CreateProductDto Dto,
    Stream? ImageStream = null,
    string? ImageFileName = null,
    string? ImageContentType = null
) : IRequest<ProductDto>;
}
