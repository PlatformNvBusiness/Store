using Microsoft.EntityFrameworkCore;
using Stores.DataAccess.Models;

namespace Stores.DataAccess.Repositories;

public class ItemRepository : BaseRepository<Item>, IItemRepository
{
    private readonly DbSet<Item> _items;
    public ItemRepository(StoreContext context) : base(context)
    {
        _items = context.Set<Item>();
    }

    public async Task<List<Item>> GetAllAsync(int storeId, CancellationToken cancellation)
    {
        return await _items.Where(item => item.StoreId == storeId).ToListAsync(cancellation);
    }
}
