using Microsoft.EntityFrameworkCore;
using Stores.DataAccess.Helpers;
using System.Linq.Expressions;

namespace Stores.DataAccess.Repositories;

/// <summary>
/// The base repository that implements the create, read, update and delete to the databae
/// </summary>
/// <typeparam name="T"><see cref="T"/> is the entity</typeparam>
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;

    /// <summary>
    /// Initializes a new instance of <see cref="BaseRepository{T}"/>
    /// </summary>
    /// <param name="context">The store context</param>
    public BaseRepository(StoreContext context)
    {
        _dbSet = context.Set<T>();
    }

    /// <summary>
    /// To Change The Entity Mode To add
    /// </summary>
    /// <param name="entity"></param>
    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    /// <summary>
    /// To change the entity mode to delete
    /// </summary>
    /// <param name="entity"></param>
    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    /// <summary>
    /// To get the entities by condition
    /// </summary>
    /// <param name="condition">The condition</param>
    /// <param name="cancellation">The cancellation</param>
    /// <returns>A <see cref="Task{List{T}}"/></returns>
    public  Task<List<T>> GetByConditionAsync(Expression<Func<T, bool>> condition, CancellationToken cancellation)
    {
        return  _dbSet.Where(condition).ToListAsync(cancellation);
    }

    /// <summary>
    /// To get the entity by id
    /// </summary>
    /// <param name="id">The id of the entity</param>
    /// <param name="cancellation">The cancellation</param>
    /// <returns>A <see cref="ValueTask{T?}"/></returns>
    public ValueTask<T?> GetByIdAsync(int id, CancellationToken cancellation)
    {
        return  _dbSet.FindAsync(id, cancellation);
    }

    /// <summary>
    /// The pagination for the entities
    /// </summary>
    /// <param name="page">The page</param>
    /// <param name="size">tThe size</param>
    /// <param name="cancellation">The cancellation</param>
    /// <returns>A <see cref="Task{List{T}}"/></returns>
    public async Task<PageResult<T>> GetByPageAsync(int page, int size, CancellationToken cancellation)
    {
        var items = await _dbSet.Skip((page - 1) * size).Take(size).ToListAsync(cancellation);
        
        var count = _dbSet.Count();

        return new PageResult<T>(size, page, count, items);
    }

    /// <summary>
    /// The method to update the entity mode
    /// </summary>
    /// <param name="entity">The entity</param>
    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
