using AutoMapper;
using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Helpers;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Helpers;
using Stores.DataAccess.Models;
using Stores.DataAccess.Repositories;

namespace Stores.BusinessLogic.Services;

public class ItemVariationService : IItemVariationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ItemVariationService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ItemVariationDto> AddAsync(ItemVariationRequest request, CancellationToken cancellationToken)
    {
        var itemVariation = _mapper.Map<ItemVariation>(request);

        _unitOfWork.ItemVariations.Add(itemVariation);
        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return _mapper.Map<ItemVariationDto>(itemVariation);
    }

    public async Task<string> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var itemVariation = await HelperFunctions.GetOneAsync<ItemVariation>(_unitOfWork.ItemVariations.GetByIdAsync, id, cancellationToken);

        _unitOfWork.ItemVariations.Delete(itemVariation);
        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return "The item variation has been deleted";
    }

    public async Task<ItemVariationDto> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _mapper.Map<ItemVariationDto>(await HelperFunctions.GetOneAsync<ItemVariation>(_unitOfWork.ItemVariations.GetByIdAsync, id, cancellationToken));
    }

    public async Task<PageResult<ItemVariationDto>> GetByPageAsync(int size, int pageNumber, CancellationToken cancellationToken)
    {
        var itemVariationsPaged = await _unitOfWork.ItemVariations.GetByPageAsync(size, pageNumber, cancellationToken);

        return _mapper.Map<PageResult<ItemVariationDto>>(itemVariationsPaged);
    }

    public async Task<ItemVariationDto> UpdateAsync(int id, ItemVariationRequest itemVariationDto, CancellationToken cancellationToken)
    {
        var itemVariation = await HelperFunctions.GetOneAsync<ItemVariation>(_unitOfWork.ItemVariations.GetByIdAsync, id, cancellationToken);

        _mapper.Map(itemVariationDto, itemVariation);

        _unitOfWork.ItemVariations.Update(itemVariation);
        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return _mapper.Map<ItemVariationDto>(itemVariationDto);
    }
}
