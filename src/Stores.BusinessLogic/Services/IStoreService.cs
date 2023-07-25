using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Helpers;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Models;

namespace Stores.BusinessLogic.Services;

public interface IStoreService
{
    public Task<StoreDto> AddAsync(StoreRequest storeRequest, CancellationToken cancellation);
    public Task<StoreDto> UpdateAsync(int id, StoreRequest storeRequest, CancellationToken cancellation);
    public Task<string> DeleteAsync(int id, int userId, CancellationToken cancellation);
    public Task<StoreDto> GetByIdAsync(int id, CancellationToken cancellation);
    public Task<PageResult<StoreDto>> GetStoresAsync(int size, int pageNumber, CancellationToken cancellation);
}
