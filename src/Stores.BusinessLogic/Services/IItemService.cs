using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Requests;

namespace Stores.BusinessLogic.Services;

public interface IItemService
{
    public Task<ItemDto> AddAsync(int storeId, ItemRequest request, CancellationToken cancellation);
    public Task<ItemDto> UpdateAsync(int storeId, int id, ItemRequest request, CancellationToken cancellation);
    public Task<string> DeleteAsync(int storeId, int id, CancellationToken cancellation);
    public Task<ItemDto> GetByIdAsync(int storeId, int id, CancellationToken cancellation);
    public Task<List<ItemDto>> GetAllAsync(int storeId, CancellationToken cancellation);
}
