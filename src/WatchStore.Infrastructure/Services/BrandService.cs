using WatchStore.Core.Domain.Entities;
using WatchStore.Core.Domain.Repositories;
using WatchStore.Core.DTOs;
using WatchStore.Core.Services;

namespace WatchStore.Infrastructure.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<BrandDto?> GetBrandByIdAsync(int id)
        {
            var brand = await _brandRepository.GetByIdAsync(id);
            return brand != null ? MapToDto(brand) : null;
        }

        public async Task<BrandListDto> GetAllBrandsAsync()
        {
            var brands = await _brandRepository.GetAllAsync();
            return new BrandListDto
            {
                Brands = brands.Select(MapToDto)
            };
        }

        public async Task<IEnumerable<BrandDto>> GetActiveBrandsAsync()
        {
            var brands = await _brandRepository.GetActiveBrandsAsync();
            return brands.Select(MapToDto);
        }

        private static BrandDto MapToDto(Brand brand)
        {
            return new BrandDto
            {
                Id = brand.Id,
                Name = brand.Name,
                Description = brand.Description,
                ImageUrl = brand.ImageUrl
            };
        }
    }
}