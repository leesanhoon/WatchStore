using Microsoft.AspNetCore.Mvc;
using WatchStore.Core.DTOs;
using WatchStore.Core.Models;
using WatchStore.Core.Services;

namespace WatchStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<ProductListDto>>> GetProducts(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? brandFilter = null,
            [FromQuery] string? sortBy = null)
        {
            try
            {
                var result = await _productService.GetProductsAsync(pageNumber, pageSize, brandFilter, sortBy);
                return Ok(ApiResponse<ProductListDto>.SuccessResult(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<ProductListDto>.ErrorResult($"Lỗi khi lấy danh sách sản phẩm: {ex.Message}"));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ProductDto>>> GetProduct(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    return NotFound(ApiResponse<ProductDto>.ErrorResult("Không tìm thấy sản phẩm"));
                }

                return Ok(ApiResponse<ProductDto>.SuccessResult(product));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<ProductDto>.ErrorResult($"Lỗi khi lấy thông tin sản phẩm: {ex.Message}"));
            }
        }

        [HttpGet("by-brand/{brand}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductDto>>>> GetProductsByBrand(string brand)
        {
            try
            {
                var products = await _productService.GetProductsByBrandAsync(brand);
                return Ok(ApiResponse<IEnumerable<ProductDto>>.SuccessResult(products));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<IEnumerable<ProductDto>>.ErrorResult($"Lỗi khi lấy sản phẩm theo thương hiệu: {ex.Message}"));
            }
        }

        [HttpGet("available")]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductDto>>>> GetAvailableProducts()
        {
            try
            {
                var products = await _productService.GetAvailableProductsAsync();
                return Ok(ApiResponse<IEnumerable<ProductDto>>.SuccessResult(products));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<IEnumerable<ProductDto>>.ErrorResult($"Lỗi khi lấy danh sách sản phẩm có sẵn: {ex.Message}"));
            }
        }
    }
}