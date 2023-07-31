using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Requests;

namespace Stores.BusinessLogic.Services;

/// <summary>
/// The item service interface
/// </summary>
public interface IItemService
{

    /// <summary>
    /// Add a new item to the database
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="request"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public Task<ItemDto> AddAsync(int storeId, ItemRequest request, CancellationToken cancellation);

    /// <summary>
    /// Update a item
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public Task<ItemDto> UpdateAsync(int storeId, int id, ItemRequest request, CancellationToken cancellation);

    /// <summary>
    /// Delete an item
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public Task<string> DeleteAsync(int storeId, int id, CancellationToken cancellation);

    /// <summary>
    /// Get an item by his id
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public Task<ItemDto> GetByIdAsync(int storeId, int id, CancellationToken cancellation);

    /// <summary>
    /// Get all the item by the store id
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public Task<List<ItemDto>> GetAllAsync(int storeId, CancellationToken cancellation);
}
