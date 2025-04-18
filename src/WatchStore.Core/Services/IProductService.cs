using WatchStore.Core.DTOs;

namespace WatchStore.Core.Services
{
    public interface IProductService
    {
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<ProductListDto> GetProductsAsync(int pageNumber = 1, int pageSize = 10, string? brandFilter = null, string? sortBy = null);
        Task<IEnumerable<ProductDto>> GetProductsByBrandAsync(string brand);
        Task<IEnumerable<ProductDto>> GetAvailableProductsAsync();
    }
}