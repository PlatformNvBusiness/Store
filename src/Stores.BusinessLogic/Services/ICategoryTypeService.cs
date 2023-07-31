using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Helpers;

namespace Stores.BusinessLogic.Services;

/// <summary>
/// The category type service
/// </summary>
public interface ICategoryTypeService
{

    /// <summary>
    /// Add a new category type
    /// </summary>
    /// <param name="categoryDto"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<CategoryTypeDto> AddAsync(CategoryTypeRequest categoryDto, CancellationToken cancellation);

    /// <summary>
    /// Update a category type
    /// </summary>
    /// <param name="id"></param>
    /// <param name="categoryDto"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<CategoryTypeDto> UpdateAsync(int id, CategoryTypeRequest categoryDto, CancellationToken cancellation);

    /// <summary>
    /// Delete a category type
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<string> DeleteAsync(int id, CancellationToken cancellation);

    /// <summary>
    /// Get categories type by page
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<PageResult<CategoryTypeDto>> GetCategoriesTypeAsync(int page, int size, CancellationToken cancellation);

    /// <summary>
    /// Get the category type by his id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<CategoryTypeDto> GetByIdAsync(int id, CancellationToken cancellation);
}
