using Microsoft.EntityFrameworkCore;
using WatchStore.Core.Domain.Entities;
using WatchStore.Core.Domain.Repositories;
using WatchStore.Infrastructure.Data;

namespace WatchStore.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _context;

        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Brand?> GetByIdAsync(int id)
        {
            return await _context.Brands.FindAsync(id);
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> AddAsync(Brand entity)
        {
            await _context.Brands.AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(Brand entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(Brand entity)
        {
            _context.Brands.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Brand>> GetActiveBrandsAsync()
        {
            return await _context.Brands
                .Where(b => b.Status)
                .ToListAsync();
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Brands
                .AnyAsync(b => b.Name.ToLower() == name.ToLower());
        }
    }
}