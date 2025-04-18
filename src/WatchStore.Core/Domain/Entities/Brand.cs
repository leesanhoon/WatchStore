using WatchStore.Core.Domain.Common;

namespace WatchStore.Core.Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}