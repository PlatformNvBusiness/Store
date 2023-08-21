using Stores.DataAccess.Models;

namespace Stores.DataAccess.Repositories;

public class PolicyRepository : BaseRepository<Policy>, IPolicyRepository
{
    public PolicyRepository(StoreContext context) : base(context)
    {
    }
}
