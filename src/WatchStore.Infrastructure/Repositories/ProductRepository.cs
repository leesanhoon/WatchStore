using Microsoft.EntityFrameworkCore;
using WatchStore.Core.Domain.Entities;
using WatchStore.Core.Domain.Repositories;
using WatchStore.Infrastructure.Data;

namespace WatchStore.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> AddAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(Product entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task DeleteAsync(Product entity)
        {
            _context.Products.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetByBrandAsync(string brand)
        {
            return await _context.Products
                .Where(p => p.Brand.Name == brand)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAvailableProductsAsync()
        {
            return await _context.Products
                .Where(p => p.Status == ProductStatus.Available)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsWithPaginationAsync(
            int pageNumber,
            int pageSize,
            string? brandFilter = null,
            string? sortBy = null)
        {
            IQueryable<Product> query = _context.Products;

            if (!string.IsNullOrWhiteSpace(brandFilter))
            {
                query = query.Where(p => p.Brand.Name == brandFilter);
            }

            // Thêm logic sắp xếp
            query = sortBy?.ToLower() switch
            {
                "price_asc" => query.OrderBy(p => p.Price),
                "price_desc" => query.OrderByDescending(p => p.Price),
                "name" => query.OrderBy(p => p.Name),
                _ => query.OrderByDescending(p => p.CreatedAt)
            };

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalProductCountAsync(string? brandFilter = null)
        {
            IQueryable<Product> query = _context.Products;

            if (!string.IsNullOrWhiteSpace(brandFilter))
            {
                query = query.Where(p => p.Brand.Name == brandFilter);
            }

            return await query.CountAsync();
        }
    }
}