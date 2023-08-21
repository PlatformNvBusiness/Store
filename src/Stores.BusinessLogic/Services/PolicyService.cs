using AutoMapper;
using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Helpers;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Helpers;
using Stores.DataAccess.Models;
using Stores.DataAccess.Repositories;

namespace Stores.BusinessLogic.Services;

public class PolicyService : IPolicyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PolicyService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<PolicyDto> AddAsync(int storeId, PolicyRequest request, CancellationToken cancellationToken)
    {
        var store = HelperFunctions.GetOneAsync<Store>(_unitOfWork.Stores.GetByIdAsync, storeId, cancellationToken);

        var policy = _mapper.Map<Policy>(request);

        _unitOfWork.Policies.Add(policy);
        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return _mapper.Map<PolicyDto>(policy);
    }

    public async Task<string> DeleteAsync(int storeId, int id, CancellationToken cancellationToken)
    {
        var policy = await HelperFunctions.GetOneAsync<Policy>(_unitOfWork.Policies.GetByIdAsync, id, cancellationToken);

        _unitOfWork.Policies.Delete(policy);
        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return "The policy has been deleted";
    }

    public async Task<PolicyDto> GetByIdAsync(int storeId, int id, CancellationToken cancellationToken)
    {
        return _mapper.Map<PolicyDto>(await HelperFunctions.GetOneAsync<Policy>(_unitOfWork.Policies.GetByIdAsync, id, cancellationToken));
    }

    public async Task<PageResult<PolicyDto>> GetByPageAsync(int page, int pageSize, CancellationToken cancellationToken)
    {
        var policyPageResult = await _unitOfWork.Policies.GetByPageAsync(page, pageSize, cancellationToken);

        return _mapper.Map<PageResult<PolicyDto>>(policyPageResult);
    }

    public async Task<PolicyDto> UpdateAsync(int storeId, int id, PolicyRequest request, CancellationToken cancellationToken)
    {
        var policy = await HelperFunctions.GetOneAsync<Policy>(_unitOfWork.Policies.GetByIdAsync, id, cancellationToken);

        _mapper.Map(request, policy);

        _unitOfWork.Policies.Update(policy);
        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return _mapper.Map<PolicyDto>(policy);
    }
}
