using AutoMapper;
using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Helpers;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Models;
using Stores.DataAccess.Repositories;

namespace Stores.BusinessLogic.Services;

public class StoreService : IStoreService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public StoreService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<StoreDto> AddAsync(StoreRequest storeRequest, CancellationToken cancellation)
    {
        var store = _mapper.Map<Store>(storeRequest);
        store.CreationDate = DateTimeOffset.Now.UtcDateTime;

        _unitOfWork.Stores.Add(store);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return _mapper.Map<StoreDto>(store);
    }

    public async Task<string> DeleteAsync(int id, int userId, CancellationToken cancellation)
    {
        var store = await HelperFunctions.GetOneAsync(_unitOfWork.Stores.GetByIdAsync, id, cancellation);

        _unitOfWork.Stores.Delete(store);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return "the store has successfully been deleted";
    }

    public async Task<StoreDto> GetByIdAsync(int id, CancellationToken cancellation)
    {
        return _mapper.Map<StoreDto>(await HelperFunctions.GetOneAsync(_unitOfWork.Stores.GetByIdAsync, id, cancellation));
    }

    public async Task<PageResult<StoreDto>> GetStoresAsync(int size, int pageNumber, CancellationToken cancellation)
    {
        var stores = await _unitOfWork.Stores.GetByPageAsync(pageNumber, size, cancellation);

        return new PageResult<StoreDto>()
        {
            Data = _mapper.Map<List<StoreDto>>(stores),
            CurrentPage = pageNumber,
            Size = size
        };
    }

    public async Task<StoreDto> UpdateAsync(int id, StoreRequest storeRequest, CancellationToken cancellation)
    {
        var store = await HelperFunctions.GetOneAsync(_unitOfWork.Stores.GetByIdAsync, id, cancellation);

        _unitOfWork.Stores.Delete(store);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return _mapper.Map<StoreDto>(store);
    }

}
