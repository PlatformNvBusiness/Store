using Stores.DataAccess.Models;

namespace Stores.DataAccess.Repositories
{
    public class CategoryTypeRepository : BaseRepository<CategoryType>, ICategoryTypeRepository
    {
        public CategoryTypeRepository(StoreContext context) : base(context)
        {

        }
    }
}
