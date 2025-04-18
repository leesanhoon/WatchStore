using WatchStore.Core.DTOs;

namespace WatchStore.Core.Services
{
    public interface IBrandService
    {
        Task<BrandDto?> GetBrandByIdAsync(int id);
        Task<BrandListDto> GetAllBrandsAsync();
        Task<IEnumerable<BrandDto>> GetActiveBrandsAsync();
    }
}