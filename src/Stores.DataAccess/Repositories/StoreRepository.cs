using Microsoft.EntityFrameworkCore;
using Stores.DataAccess.Models;
using System.Linq.Expressions;

namespace Stores.DataAccess.Repositories
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        public StoreRepository(StoreContext context) : base(context)
        {
       
        }
    }
}
