using Microsoft.EntityFrameworkCore;
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

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<List<T>> GetByConditionAsync(Expression<Func<T, bool>> condition, CancellationToken cancellation)
    {
        return await _dbSet.Where(condition).ToListAsync(cancellation);
    }

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellation)
    {
        return await _dbSet.FindAsync(id, cancellation);
    }

    public Task<List<T>> GetByPageAsync(int page, int size, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellation)
    {
        return await _dbSet.ToListAsync(cancellation);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
