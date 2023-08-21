using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Helpers;

namespace Stores.BusinessLogic.Services;

public interface IItemVariationService
{
    public  Task<ItemVariationDto> AddAsync(ItemVariationRequest request, CancellationToken cancellationToken);
    public  Task<ItemVariationDto> UpdateAsync(int id, ItemVariationRequest itemVariationDto, CancellationToken cancellationToken);
    public Task<string> DeleteAsync(int id, CancellationToken cancellationToken);
    public Task<ItemVariationDto> GetByIdAsync(int id, CancellationToken cancellationToken);
    public Task<PageResult<ItemVariationDto>> GetByPageAsync(int size, int pageNumber, CancellationToken cancellationToken);
}
