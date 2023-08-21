using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Helpers;

namespace Stores.BusinessLogic.Services;

public interface IFaqService
{
    Task<FaqDto> AddAsync(FaqRequest request, CancellationToken cancellationToken);
    Task<FaqDto> UpdateAsync(int id, FaqRequest request, CancellationToken cancellationToken);
    Task<string> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<FaqDto> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<PageResult<FaqDto>> GetByPageAsync(int  page, int pageSize, CancellationToken cancellationToken);
}
