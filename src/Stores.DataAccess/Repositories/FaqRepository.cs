using Stores.DataAccess.Models;

namespace Stores.DataAccess.Repositories;

public class FaqRepository : BaseRepository<Faq>, IFaqRepository
{
    public FaqRepository(StoreContext context) : base(context)
    {

    }
}
