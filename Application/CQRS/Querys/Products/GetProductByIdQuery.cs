using EasyReach_Application.DTOs.Catalogs;
using MediatR;
using System;

namespace EasyReach_Application.CQRS.Querys.Products
{
    public record GetProductByIdQuery(Guid Id) : IRequest<ProductDto>;
}