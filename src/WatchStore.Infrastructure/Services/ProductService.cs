using WatchStore.Core.Domain.Entities;
using WatchStore.Core.Domain.Repositories;
using WatchStore.Core.DTOs;
using WatchStore.Core.Services;

namespace WatchStore.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product != null ? MapToDto(product) : null;
        }

        public async Task<ProductListDto> GetProductsAsync(
            int pageNumber = 1,
            int pageSize = 10,
            string? brandFilter = null,
            string? sortBy = null)
        {
            var products = await _productRepository.GetProductsWithPaginationAsync(
                pageNumber,
                pageSize,
                brandFilter,
                sortBy
            );

            var totalCount = await _productRepository.GetTotalProductCountAsync(brandFilter);
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            return new ProductListDto
            {
                Products = products.Select(MapToDto),
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByBrandAsync(string brand)
        {
            var products = await _productRepository.GetByBrandAsync(brand);
            return products.Select(MapToDto);
        }

        public async Task<IEnumerable<ProductDto>> GetAvailableProductsAsync()
        {
            var products = await _productRepository.GetAvailableProductsAsync();
            return products.Select(MapToDto);
        }

        private static ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Brand = product.Brand,
                Model = product.Model,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Status = product.Status.ToString(),
                Availability = product.Status == ProductStatus.Available
                    ? "Có sẵn - Giao hàng ngay"
                    : $"Đặt hàng - {product.DeliveryTime} ngày",
                DeliveryTime = product.DeliveryTime
            };
        }
    }
}