using WatchStore.Core.Domain.Entities;

namespace WatchStore.Core.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetByBrandAsync(string brand);
        Task<IEnumerable<Product>> GetAvailableProductsAsync();
        Task<IEnumerable<Product>> GetProductsWithPaginationAsync(int pageNumber, int pageSize, string? brandFilter = null, string? sortBy = null);
        Task<int> GetTotalProductCountAsync(string? brandFilter = null);
    }
}