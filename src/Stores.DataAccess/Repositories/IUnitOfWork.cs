using Stores.DataAccess.Models;

namespace Stores.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        public IItemRepository Items { get; set; }
        public IStoreRepository Stores { get; set; }
        public ICategoryRepository Categories { get; set; }
        public ICategoryTypeRepository CategoryTypes { get; set; }
        public Task CommitChangesAsync(CancellationToken cancellation);
    }
}
