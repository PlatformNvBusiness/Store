using Stores.DataAccess.Models;

namespace Stores.DataAccess.Repositories;

/// <summary>
/// The category type repository implementation
/// </summary>
public class CategoryTypeRepository : BaseRepository<CategoryType>, ICategoryTypeRepository
{
    
    /// <summary>
    /// Initiazes a new instance of <see cref="CategoryTypeRepository"/>
    /// </summary>
    /// <param name="context">The context</param>
    public CategoryTypeRepository(StoreContext context) : base(context)
    {

    }
}
