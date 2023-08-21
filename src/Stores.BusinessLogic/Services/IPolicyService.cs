using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Helpers;

namespace Stores.BusinessLogic.Services;

public interface IPolicyService
{
    Task<PolicyDto> AddAsync(int storeId, PolicyRequest request, CancellationToken cancellationToken);
    Task<PolicyDto> UpdateAsync(int storeId, int id, PolicyRequest request, CancellationToken cancellationToken);    
    Task<string> DeleteAsync(int storeId, int id, CancellationToken cancellationToken);
    Task<PolicyDto> GetByIdAsync(int storeId, int id, CancellationToken cancellationToken);
    Task<PageResult<PolicyDto>> GetByPageAsync(int page, int pageSize, CancellationToken cancellationToken);
}
