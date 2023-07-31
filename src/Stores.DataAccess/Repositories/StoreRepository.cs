using Stores.DataAccess.Models;

namespace Stores.DataAccess.Repositories;

/// <summary>
/// The store repository implementation
/// </summary>
public class StoreRepository : BaseRepository<Store>, IStoreRepository
{

    /// <summary>
    /// Initializes a new instance of <see cref="StoreRepository"/>
    /// </summary>
    /// <param name="context">The store context</param>
    public StoreRepository(StoreContext context) : base(context)
    {

    }
}
