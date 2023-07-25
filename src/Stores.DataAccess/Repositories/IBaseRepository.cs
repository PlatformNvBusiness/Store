using System.Linq.Expressions;

namespace Stores.DataAccess.Repositories;

public interface IBaseRepository<E> where E : class
{
    public void Add(E entity);
    public void Delete(E entity);
    public void Update(E entity);
    public Task<E?> GetByIdAsync(int id, CancellationToken cancellation);
    public Task<List<E>> GetByPageAsync(int page, int size, CancellationToken cancellation);
    public Task<List<E>> GetByConditionAsync(Expression<Func<E, bool>> condition, CancellationToken cancellation);
    public Task<List<E>> GetAllAsync(CancellationToken cancellation);
}
