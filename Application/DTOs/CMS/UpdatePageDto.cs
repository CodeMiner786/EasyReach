namespace EasyReach_Application.DTOs.CMS
{
    public class UpdatePageDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty; // এখানে get; set; হবে
        public bool IsPublished { get; set; }
        public List<Guid> BannerIds { get; set; } = [];
        public List<CreatePageProductMappingDto> Products { get; set; } = [];
    }
}
