using EasyReach_Application.DTOs.CMS;
using MediatR;
using System;
using System.IO;

namespace EasyReach_Application.CQRS.Commands.CMS
{
    public record CreateBannerCommand(CreateBannerDto Dto, Stream? FileStream, string? FileName, string? ContentType) : IRequest<Guid>;
    public record UpdateBannerCommand(UpdateBannerDto Dto, Stream? FileStream, string? FileName, string? ContentType) : IRequest<bool>;
    public record DeleteBannerCommand(Guid Id) : IRequest<bool>;
}

