using Microsoft.Extensions.Logging;

namespace Stores.DataAccess.Repositories
{
    /// <summary>
    /// The unit of work class representing the unit of work pattern
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly StoreContext _storeContext;
        private readonly ILogger<UnitOfWork> _logger;

        /// <summary>
        /// The Item repository
        /// </summary>
        public IItemRepository Items { get; set ; }

        /// <summary>
        /// The store repository
        /// </summary>
        public IStoreRepository Stores { get ; set; }

        /// <summary>
        /// The category repository
        /// </summary>
        public ICategoryRepository Categories { get; set; }

        /// <summary>
        /// The category types repository
        /// </summary>
        public ICategoryTypeRepository CategoryTypes { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="UnitOfWork"/>
        /// </summary>
        /// <param name="logger">The logger to log information on the console and in the sinks</param>
        /// <param name="storeContext">The store context</param>
        /// <param name="items">The item repository</param>
        /// <param name="stores">The store repostitory</param>
        /// <param name="categories">The category repository</param>
        public UnitOfWork(ILogger<UnitOfWork> logger, StoreContext storeContext,
            IItemRepository items,
            IStoreRepository stores,
            ICategoryRepository categories,
            ICategoryTypeRepository categoryTypes)
        {
            _logger = logger;
            _storeContext = storeContext;
            Items = items;
            Stores = stores;
            Categories = categories;
            CategoryTypes = categoryTypes;
        }

        /// <summary>
        /// Function to commit  all the changes to the database
        /// </summary>
        /// <param name="cancellation">The cancellation token to cancel an action when requested</param>
        /// <returns><see cref="Task"/></returns>
        public async Task CommitChangesAsync(CancellationToken cancellation)
        {
            _logger.LogInformation("committing the changes");

            await _storeContext.SaveChangesAsync(cancellation);
        }

        /// <summary>
        /// Function dispose to dispose the object unit of work
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Function dispose to dispose the object unit of work
        /// </summary>
        /// <param name="disposing">To see if the object can be disposed</param>
        public void Dispose(bool disposing)
        {
            if(disposing)
            {
                _storeContext.Dispose();
            }
        }
    }
}
