using EasyReach_Application.DTOs.LandingPages;
using EasyReach_Application.DTOs.LandingPages.LandingPageProductItems;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyReach_Application.CQRS.Querys.LandingPages
{
    public record GetLandingPageBySlugQuery(string Slug) : IRequest<LandingPageResponseDto?>;
}
