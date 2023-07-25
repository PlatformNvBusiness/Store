using AutoMapper;
using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Helpers;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Models;
using Stores.DataAccess.Repositories;

namespace Stores.BusinessLogic.Services
{
    public class CategoryTypeService : ICategoryTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryTypeDto> AddAsync(CategoryTypeRequest categoryDto, CancellationToken cancellation)
        {
            var categoryType = _mapper.Map<CategoryType>(categoryDto);

            _unitOfWork.CategoryTypes.Add(categoryType);
            await _unitOfWork.CommitChangesAsync(cancellation);

            return _mapper.Map<CategoryTypeDto>(categoryType);
        }

        public async Task<string> DeleteAsync(int id, CancellationToken cancellation)
        {
            var categoryTypeLooked = await HelperFunctions.GetOneAsync(_unitOfWork.CategoryTypes.GetByIdAsync, id, cancellation);

            _unitOfWork.CategoryTypes.Delete(categoryTypeLooked);
            await _unitOfWork.CommitChangesAsync(cancellation);

            return "The entity has been deleted";
        }

        public async Task<CategoryTypeDto> GetByIdAsync(int id, CancellationToken cancellation)
        {
            var categoryType = await HelperFunctions.GetOneAsync(_unitOfWork.CategoryTypes.GetByIdAsync, id, cancellation);

            return _mapper.Map<CategoryTypeDto>(categoryType);
        }

        public async Task<List<CategoryTypeDto>> GetCategoriesTypeAsync(CancellationToken cancellation)
        {
            return _mapper.Map<List<CategoryTypeDto>>(await _unitOfWork.CategoryTypes.GetAllAsync(cancellation));
        }

        public async Task<CategoryTypeDto> UpdateAsync(int id, CategoryTypeRequest categoryDto, CancellationToken cancellation)
        {
            var categoryTypeLooked = await HelperFunctions.GetOneAsync(_unitOfWork.CategoryTypes.GetByIdAsync, id, cancellation);

            _mapper.Map(categoryDto, categoryTypeLooked);

            _unitOfWork.CategoryTypes.Update(categoryTypeLooked);
            await _unitOfWork.CommitChangesAsync(cancellation);

            return _mapper.Map<CategoryTypeDto>(categoryTypeLooked);
        }

        
    }
}
