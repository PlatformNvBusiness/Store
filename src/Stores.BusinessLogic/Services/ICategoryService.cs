using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Requests;

namespace Stores.BusinessLogic.Services
{
    public interface ICategoryService
    {
        Task<CategoryDto> AddAsync(CategoryRequest categoryDto, CancellationToken cancellation);
        Task<CategoryDto> UpdateAsync(int id, CategoryRequest categoryDto, CancellationToken cancellation);
        Task<string> DeleteAsync(int id, CancellationToken cancellation);
        Task<List<CategoryDto>> GetCategoriesAsync(CancellationToken cancellation);
        Task<CategoryDto> GetByIdAsync(int id, CancellationToken cancellation);
    }
}
