using System;

namespace EasyReach_Application.DTOs.CMS
{
    public class PageDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsPublished { get; set; }
        public List<BannerDto> Banners { get; set; } = [];
        public List<PageProductItemDto> Products { get; set; } = [];
    }
}
