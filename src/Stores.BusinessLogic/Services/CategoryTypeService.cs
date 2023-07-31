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
public class CategoryTypeService : ICategoryTypeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of <see cref="CategoryTypeService"/>
    /// </summary>
    /// <param name="unitOfWork"></param>
    /// <param name="mapper"></param>
    public CategoryTypeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="categoryDto"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<CategoryTypeDto> AddAsync(CategoryTypeRequest categoryDto, CancellationToken cancellation)
    {
        var categoryType = _mapper.Map<CategoryType>(categoryDto);

        _unitOfWork.CategoryTypes.Add(categoryType);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return _mapper.Map<CategoryTypeDto>(categoryType);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<string> DeleteAsync(int id, CancellationToken cancellation)
    {
        var categoryTypeLooked = await HelperFunctions.GetOneAsync(_unitOfWork.CategoryTypes.GetByIdAsync, id, cancellation);

        _unitOfWork.CategoryTypes.Delete(categoryTypeLooked);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return "The entity has been deleted";
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<CategoryTypeDto> GetByIdAsync(int id, CancellationToken cancellation)
    {
        var categoryType = await HelperFunctions.GetOneAsync(_unitOfWork.CategoryTypes.GetByIdAsync, id, cancellation);

        return _mapper.Map<CategoryTypeDto>(categoryType);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<PageResult<CategoryTypeDto>> GetCategoriesTypeAsync(int page, int size, CancellationToken cancellation)
    {
        return _mapper.Map<PageResult<CategoryTypeDto>>(await _unitOfWork.CategoryTypes.GetByPageAsync(page, size, cancellation));
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="categoryDto"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<CategoryTypeDto> UpdateAsync(int id, CategoryTypeRequest categoryDto, CancellationToken cancellation)
    {
        var categoryTypeLooked = await HelperFunctions.GetOneAsync(_unitOfWork.CategoryTypes.GetByIdAsync, id, cancellation);

        _mapper.Map(categoryDto, categoryTypeLooked);

        _unitOfWork.CategoryTypes.Update(categoryTypeLooked);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return _mapper.Map<CategoryTypeDto>(categoryTypeLooked);
    }

    
}
