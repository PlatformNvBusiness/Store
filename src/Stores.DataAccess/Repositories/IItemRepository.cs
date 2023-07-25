using Stores.DataAccess.Models;

namespace Stores.DataAccess.Repositories;

public interface IItemRepository : IBaseRepository<Item>
{
    public Task<List<Item>> GetAllAsync(int storeId, CancellationToken cancellation);
}
