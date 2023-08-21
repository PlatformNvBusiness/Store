namespace Stores.DataAccess.Repositories
{

    /// <summary>
    /// The interface of the unit of work
    /// </summary>
    public interface IUnitOfWork
    {

        /// <summary>
        /// The item repistory
        /// </summary>
        public IItemRepository Items { get; set; }

        /// <summary>
        /// The store repository
        /// </summary>
        public IStoreRepository Stores { get; set; }

        /// <summary>
        /// The cateogry repository
        /// </summary>
        public ICategoryRepository Categories { get; set; }

        /// <summary>
        /// The cateogry repository
        /// </summary>
        public ICategoryTypeRepository CategoryTypes { get; set; }

        /// <summary>
        /// The item variations
        /// </summary>
        public IItemVariationRepository ItemVariations { get; set; }

        /// <summary>
        /// The repository for frequently asked questions
        /// </summary>
        public IFaqRepository Faqs { get; set; }

        public IPolicyRepository Policies { get; set; }

        /// <summary>
        /// The commit changes function to commit all the changes to the database
        /// </summary>
        /// <param name="cancellation">The cancellation</param>
        /// <returns>A <see cref="Task"/></returns>
        public Task CommitChangesAsync(CancellationToken cancellation);
    }
}
