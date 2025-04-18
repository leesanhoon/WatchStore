using WatchStore.Core.Domain.Common;

namespace WatchStore.Core.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public ProductStatus Status { get; set; } = ProductStatus.Available;
        public int? DeliveryTime { get; set; } // Số ngày dự kiến giao hàng nếu cần đặt hàng
    }

    public enum ProductStatus
    {
        Available, // Có sẵn
        PreOrder   // Cần đặt hàng
    }
}