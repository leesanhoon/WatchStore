namespace WatchStore.Core.DTOs
{
    public class BrandDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }

    public class BrandListDto
    {
        public IEnumerable<BrandDto> Brands { get; set; } = new List<BrandDto>();
    }
}