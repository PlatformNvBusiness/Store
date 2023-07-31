using AutoMapper;
using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Helpers;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Models;
using Stores.DataAccess.Repositories;

namespace Stores.BusinessLogic.Services;

/// <summary>
/// The item service implementation
/// </summary>
public class ItemService : IItemService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of <see cref="ItemService"/>
    /// </summary>
    /// <param name="unitOfWork"></param>
    /// <param name="mapper"></param>
    public ItemService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="request"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<ItemDto> AddAsync(int storeId, ItemRequest request, CancellationToken cancellation)
    {
        var store = await HelperFunctions.GetOneAsync(_unitOfWork.Stores.GetByIdAsync, storeId, cancellation);

        var item = _mapper.Map<Item>(request);
        item.StoreId = store.Id;

        _unitOfWork.Items.Add(item);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return _mapper.Map<ItemDto>(item);
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<string> DeleteAsync(int storeId, int id, CancellationToken cancellation)
    {
        var item = await HelperFunctions.GetOneAsync(_unitOfWork.Items.GetByIdAsync, id, cancellation);

        _unitOfWork.Items.Delete(item);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return "The item has been deleted";
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<List<ItemDto>> GetAllAsync(int storeId, CancellationToken cancellation)
    {
        return _mapper.Map<List<ItemDto>>(await _unitOfWork.Items.GetAllAsync(storeId, cancellation));
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<ItemDto> GetByIdAsync(int storeId, int id, CancellationToken cancellation)
    {
        return _mapper.Map<ItemDto>(await HelperFunctions.GetOneAsync(_unitOfWork.Items.GetByIdAsync, id, cancellation));
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public async Task<ItemDto> UpdateAsync(int storeId, int id, ItemRequest request, CancellationToken cancellation)
    {
        var item = await HelperFunctions.GetOneAsync(_unitOfWork.Items.GetByIdAsync, id, cancellation);

        _mapper.Map(item, request);

        _unitOfWork.Items.Update(item);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return _mapper.Map<ItemDto>(item);
    }
}
