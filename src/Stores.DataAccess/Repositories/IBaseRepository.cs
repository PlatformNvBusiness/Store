using Stores.DataAccess.Helpers;
using System.Linq.Expressions;

namespace Stores.DataAccess.Repositories;

/// <summary>
/// The interface for the repostitories
/// </summary>
/// <typeparam name="E">The</typeparam>
public interface IBaseRepository<T> where T : class
{

    /// <summary>
    /// To change the entity mode to add
    /// </summary>
    /// <param name="entity">The entity</param>
    public void Add(T entity);

    /// <summary>
    /// To change the entity mode to delete
    /// </summary>
    /// <param name="entity">The entity</param>
    public void Delete(T entity);

    /// <summary>
    /// To change the entity mode to update
    /// </summary>
    /// <param name="entity">The entity</param>
    public void Update(T entity);

    /// <summary>
    /// To get the entity by id
    /// </summary>
    /// <param name="id">The id </param>
    /// <param name="cancellation">The cancellation token</param>
    /// <returns>A <see cref="Task{T}"/></returns>
    public ValueTask<T?> GetByIdAsync(int id, CancellationToken cancellation);

    /// <summary>
    /// To get the entity by page
    /// </summary>
    /// <param name="page">The page</param>
    /// <param name="size">The size</param>
    /// <param name="cancellation">The cancellation</param>
    /// <returns>A <see cref="Task{List{T}}"/></returns>
    public Task<PageResult<T>> GetByPageAsync(int page, int size, CancellationToken cancellation);

    /// <summary>
    /// To get entity by condition
    /// </summary>
    /// <param name="condition">The condition</param>
    /// <param name="cancellation">The cancellation</param>
    /// <returns></returns>
    public Task<List<T>> GetByConditionAsync(Expression<Func<T, bool>> condition, CancellationToken cancellation);
}
