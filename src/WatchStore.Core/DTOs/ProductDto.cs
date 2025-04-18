namespace WatchStore.Core.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Availability { get; set; } = string.Empty;
        public int? DeliveryTime { get; set; }
    }

    public class ProductListDto
    {
        public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }
}