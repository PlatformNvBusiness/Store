using AutoMapper;
using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Exceptions;
using Stores.BusinessLogic.Helpers;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Models;
using Stores.DataAccess.Repositories;

namespace Stores.BusinessLogic.Services;

public class ItemService : IItemService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ItemService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ItemDto> AddAsync(int storeId, ItemRequest request, CancellationToken cancellation)
    {
        var store = await HelperFunctions.GetOneAsync(_unitOfWork.Stores.GetByIdAsync, storeId, cancellation);

        var item = _mapper.Map<Item>(request);
        item.StoreId = store.Id;

        _unitOfWork.Items.Add(item);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return _mapper.Map<ItemDto>(item);
    }

    public async Task<string> DeleteAsync(int storeId, int id, CancellationToken cancellation)
    {
        var item = await HelperFunctions.GetOneAsync(_unitOfWork.Items.GetByIdAsync, id, cancellation);

        _unitOfWork.Items.Delete(item);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return "The item has been deleted";
    }

    public async Task<List<ItemDto>> GetAllAsync(int storeId, CancellationToken cancellation)
    {
        return _mapper.Map<List<ItemDto>>(await _unitOfWork.Items.GetAllAsync(storeId, cancellation));
    }

    public async Task<ItemDto> GetByIdAsync(int storeId, int id, CancellationToken cancellation)
    {
        return _mapper.Map<ItemDto>(await HelperFunctions.GetOneAsync(_unitOfWork.Items.GetByIdAsync, id, cancellation));
    }

    public async Task<ItemDto> UpdateAsync(int storeId, int id, ItemRequest request, CancellationToken cancellation)
    {
        var item = await HelperFunctions.GetOneAsync(_unitOfWork.Items.GetByIdAsync, id, cancellation);

        _mapper.Map(item, request);

        _unitOfWork.Items.Update(item);
        await _unitOfWork.CommitChangesAsync(cancellation);

        return _mapper.Map<ItemDto>(item);
    }

}
