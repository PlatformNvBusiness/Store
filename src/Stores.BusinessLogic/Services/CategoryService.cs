using AutoMapper;
using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Exceptions;
using Stores.BusinessLogic.Helpers;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Models;
using Stores.DataAccess.Repositories;

namespace Stores.BusinessLogic.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CategoryDto> AddAsync(CategoryRequest categoryRequest, CancellationToken cancellation)
    {
        var categoryMapped = _mapper.Map<Category>(categoryRequest);
        _unitOfWork.Categories.Add(categoryMapped);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return _mapper.Map<CategoryDto>(categoryMapped);
    }

    public async Task<string> DeleteAsync(int id, CancellationToken cancellation)
    {
        var category = await  HelperFunctions.GetOneAsync(_unitOfWork.Categories.GetByIdAsync, id, cancellation);

        _unitOfWork.Categories.Delete(category);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return "The category has been deleted";
    }

    public async Task<CategoryDto> GetByIdAsync(int id, CancellationToken cancellation)
    {
        var category = await HelperFunctions.GetOneAsync(_unitOfWork.Categories.GetByIdAsync, id, cancellation);

        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<List<CategoryDto>> GetCategoriesAsync(CancellationToken cancellation)
    {
        var categories = await _unitOfWork.Categories.GetAllAsync(cancellation);

        return _mapper.Map<List<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> UpdateAsync(int id, CategoryRequest categoryDto, CancellationToken cancellation)
    {
        var categoryLooked = await HelperFunctions.GetOneAsync(_unitOfWork.Categories.GetByIdAsync, id, cancellation); ;

        _mapper.Map(categoryLooked, categoryDto);

        return _mapper.Map<CategoryDto>(categoryLooked);
    }
}