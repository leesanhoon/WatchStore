using WatchStore.Core.Domain.Common;

namespace WatchStore.Core.Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool Status { get; set; } = true;

        // Navigation property để quản lý mối quan hệ 1-n với Product
        // Một Brand có thể có nhiều Product
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}