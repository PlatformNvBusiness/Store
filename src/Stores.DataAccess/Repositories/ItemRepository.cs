using Microsoft.EntityFrameworkCore;
using Stores.DataAccess.Models;

namespace Stores.DataAccess.Repositories;

/// <summary>
/// The Item repository implementation
/// </summary>
public class ItemRepository : BaseRepository<Item>, IItemRepository
{
    private readonly DbSet<Item> _items;

    /// <summary>
    /// Initializes a new instance of <see cref="ItemRepository"/>
    /// </summary>
    /// <param name="context"></param>
    public ItemRepository(StoreContext context) : base(context)
    {
        _items = context.Set<Item>();
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="cancellation"></param>
    /// <returns>A Task<see cref="List{T}"/></returns>
    public async Task<List<Item>> GetAllAsync(int storeId, CancellationToken cancellation)
    {
        return await _items.Where(item => item.StoreId == storeId).ToListAsync(cancellation);
    }
}
