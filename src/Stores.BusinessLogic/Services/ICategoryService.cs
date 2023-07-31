using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Helpers;

namespace Stores.BusinessLogic.Services;

/// <summary>
/// The category service interface
/// </summary>
public interface ICategoryService
{

    /// <summary>
    /// Add A new category to the database
    /// </summary>
    /// <param name="categoryRequest">The category requests</param>
    /// <param name="cancellation">The cancellation</param>
    /// <returns>A <see cref="Task{CategoryDto}"/></returns>
    Task<CategoryDto> AddAsync(CategoryRequest categoryRequest, CancellationToken cancellation);

    /// <summary>
    /// Update a category in the database
    /// </summary>
    /// <param name="id">The id </param>
    /// <param name="categoryRequest"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<CategoryDto> UpdateAsync(int id, CategoryRequest categoryRequest, CancellationToken cancellation);

    /// <summary>
    /// Delete a category from the database
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<string> DeleteAsync(int id, CancellationToken cancellation);

    /// <summary>
    /// Get the categories by pages
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<PageResult<CategoryDto>> GetCategoriesAsync(int page, int size, CancellationToken cancellation);

    /// <summary>
    /// Get The category by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    Task<CategoryDto> GetByIdAsync(int id, CancellationToken cancellation);
}
