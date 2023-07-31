using Stores.DataAccess.Models;

namespace Stores.DataAccess.Repositories;

/// <summary>
/// The item repository interface
/// </summary>
public interface IItemRepository : IBaseRepository<Item>
{
    /// <summary>
    /// The function to get the item of the store
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public Task<List<Item>> GetAllAsync(int storeId, CancellationToken cancellation);
}
