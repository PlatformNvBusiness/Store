using Stores.DataAccess.Models;

namespace Stores.DataAccess.Repositories;

/// <summary>
/// The item variation repository implementation
/// </summary>
public class ItemVariationRepository : BaseRepository<ItemVariation>, IItemVariationRepository
{

    /// <summary>
    /// Initializes a new instance of <see cref="ItemVariationRepository"/>
    /// </summary>
    /// <param name="context">The context</param>
    public ItemVariationRepository(StoreContext context) : base(context)
    {
    }
}
