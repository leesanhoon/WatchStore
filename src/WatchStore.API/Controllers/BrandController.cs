using Microsoft.AspNetCore.Mvc;
using WatchStore.Core.DTOs;
using WatchStore.Core.Models;
using WatchStore.Core.Services;

namespace WatchStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<BrandListDto>>> GetBrands()
        {
            try
            {
                var result = await _brandService.GetAllBrandsAsync();
                return Ok(ApiResponse<BrandListDto>.SuccessResult(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<BrandListDto>.ErrorResult($"Lỗi khi lấy danh sách thương hiệu: {ex.Message}"));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<BrandDto>>> GetBrand(int id)
        {
            try
            {
                var brand = await _brandService.GetBrandByIdAsync(id);
                if (brand == null)
                {
                    return NotFound(ApiResponse<BrandDto>.ErrorResult("Không tìm thấy thương hiệu"));
                }

                return Ok(ApiResponse<BrandDto>.SuccessResult(brand));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<BrandDto>.ErrorResult($"Lỗi khi lấy thông tin thương hiệu: {ex.Message}"));
            }
        }

        [HttpGet("active")]
        public async Task<ActionResult<ApiResponse<IEnumerable<BrandDto>>>> GetActiveBrands()
        {
            try
            {
                var brands = await _brandService.GetActiveBrandsAsync();
                return Ok(ApiResponse<IEnumerable<BrandDto>>.SuccessResult(brands));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<IEnumerable<BrandDto>>.ErrorResult($"Lỗi khi lấy danh sách thương hiệu đang hoạt động: {ex.Message}"));
            }
        }
    }
}