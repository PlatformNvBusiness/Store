using AutoMapper;
using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Helpers;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Helpers;
using Stores.DataAccess.Models;
using Stores.DataAccess.Repositories;

namespace Stores.BusinessLogic.Services;

/// <summary>
/// The store service implementation
/// </summary>
public class StoreService : IStoreService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of<see cref="StoreService"/>
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="unitOfWork"></param>
    public StoreService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="storeRequest"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<StoreDto> AddAsync(StoreRequest storeRequest, CancellationToken cancellation)
    {
        var store = _mapper.Map<Store>(storeRequest);
        store.CreationDate = DateTimeOffset.Now.UtcDateTime;

        _unitOfWork.Stores.Add(store);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return _mapper.Map<StoreDto>(store);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="userId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<string> DeleteAsync(int id, int userId, CancellationToken cancellation)
    {
        var store = await HelperFunctions.GetOneAsync(_unitOfWork.Stores.GetByIdAsync, id, cancellation);

        _unitOfWork.Stores.Delete(store);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return "the store has successfully been deleted";
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<StoreDto> GetByIdAsync(int id, CancellationToken cancellation)
    {
        return _mapper.Map<StoreDto>(await HelperFunctions.GetOneAsync(_unitOfWork.Stores.GetByIdAsync, id, cancellation));
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="size"></param>
    /// <param name="pageNumber"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<PageResult<StoreDto>> GetStoresAsync(int size, int pageNumber, CancellationToken cancellation)
    {
        var storesPaged = await _unitOfWork.Stores.GetByPageAsync(pageNumber, size, cancellation);

        return _mapper.Map<PageResult<StoreDto>>(storesPaged);
    }

    /// <summary>
    ///<inheritdoc/> 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="storeRequest"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<StoreDto> UpdateAsync(int id, StoreRequest storeRequest, CancellationToken cancellation)
    {
        var store = await HelperFunctions.GetOneAsync(_unitOfWork.Stores.GetByIdAsync, id, cancellation);

        _unitOfWork.Stores.Delete(store);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return _mapper.Map<StoreDto>(store);
    }

}
