using WatchStore.Core.Domain.Entities;

namespace WatchStore.Core.Domain.Repositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<IEnumerable<Brand>> GetActiveBrandsAsync();
        Task<bool> ExistsByNameAsync(string name);
    }
}