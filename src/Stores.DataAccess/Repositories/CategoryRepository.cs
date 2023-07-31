using Stores.DataAccess.Models;

namespace Stores.DataAccess.Repositories;

/// <summary>
/// The category repository implementation
/// </summary>
public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{

    /// <summary>
    /// Initializes a new instance of <see cref="CategoryRepository"/>
    /// </summary>
    /// <param name="context">The context</param>
    public CategoryRepository(StoreContext context) : base(context)
    {

    }
}
