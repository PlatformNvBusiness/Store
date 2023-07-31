using AutoMapper;
using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Helpers;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Helpers;
using Stores.DataAccess.Models;
using Stores.DataAccess.Repositories;

namespace Stores.BusinessLogic.Services;

/// <summary>
/// The category service implementation
/// </summary>
public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of <see cref="CategoryService"/>
    /// </summary>
    /// <param name="unitOfWork"></param>
    /// <param name="mapper"></param>
    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="categoryRequest"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<CategoryDto> AddAsync(CategoryRequest categoryRequest, CancellationToken cancellation)
    {
        var categoryMapped = _mapper.Map<Category>(categoryRequest);

        _unitOfWork.Categories.Add(categoryMapped);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return _mapper.Map<CategoryDto>(categoryMapped);
    }

    /// <summary>
    /// <inheritdoc'/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<string> DeleteAsync(int id, CancellationToken cancellation)
    {
        var category = await  HelperFunctions.GetOneAsync(_unitOfWork.Categories.GetByIdAsync, id, cancellation);

        _unitOfWork.Categories.Delete(category);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return "The category has been deleted";
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<CategoryDto> GetByIdAsync(int id, CancellationToken cancellation)
    {
        var category = await HelperFunctions.GetOneAsync(_unitOfWork.Categories.GetByIdAsync, id, cancellation);

        return _mapper.Map<CategoryDto>(category);
    }

    /// <summary>
    /// <inheritdoc'/>
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<PageResult<CategoryDto>> GetCategoriesAsync(int page, int size, CancellationToken cancellation)
    {
        var categoriesPaged = await _unitOfWork.Categories.GetByPageAsync(page, size, cancellation);

        return _mapper.Map<PageResult<CategoryDto>>(categoriesPaged);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="categoryDto"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<CategoryDto> UpdateAsync(int id, CategoryRequest categoryDto, CancellationToken cancellation)
    {
        var categoryLooked = await HelperFunctions.GetOneAsync(_unitOfWork.Categories.GetByIdAsync, id, cancellation); ;

        _mapper.Map(categoryLooked, categoryDto);

        return _mapper.Map<CategoryDto>(categoryLooked);
    }
}