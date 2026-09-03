using System;

namespace EasyReach_Application.DTOs.CMS
{
    public class CreatePageDto
    {
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsPublished { get; set; } = true;
        public List<Guid> BannerIds { get; set; } = [];
        public List<CreatePageProductMappingDto> Products { get; set; } = [];
    }
}
