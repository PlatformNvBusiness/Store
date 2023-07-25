using Stores.BusinessLogic.Exceptions;

namespace Stores.BusinessLogic.Helpers;
public static class HelperFunctions
{
    /// <summary>
    /// To get one entity  from the database
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
    /// <param name="getByIdAsync">The function to get the item by id from the repository</param>
    /// <param name="id">The id of the item looked</param>
    /// <param name="cancellation">The cancellation token</param>
    /// <returns>A <see cref="Task{T}"/></returns>
    /// <exception cref="NotFoundException">Whenthe item can not be found int the database</exception>
    public static async Task<T> GetOneAsync<T>(Func<int, CancellationToken, Task<T>> getByIdAsync, int id, CancellationToken cancellation)
    {
        var item = await getByIdAsync(id, cancellation);

        if (item is null)
        {
            throw new NotFoundException($"the item was not found");
        }

        return item;
    }
}

