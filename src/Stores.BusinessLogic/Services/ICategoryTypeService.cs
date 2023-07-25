using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Requests;

namespace Stores.BusinessLogic.Services
{
    public interface ICategoryTypeService
    {
        Task<CategoryTypeDto> AddAsync(CategoryTypeRequest categoryDto, CancellationToken cancellation);
        Task<CategoryTypeDto> UpdateAsync(int id, CategoryTypeRequest categoryDto, CancellationToken cancellation);
        Task<string> DeleteAsync(int id, CancellationToken cancellation);
        Task<List<CategoryTypeDto>> GetCategoriesTypeAsync(CancellationToken cancellation);
        Task<CategoryTypeDto> GetByIdAsync(int id, CancellationToken cancellation);
    }
}
