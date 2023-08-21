using AutoMapper;
using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Helpers;
using Stores.BusinessLogic.Requests;
using Stores.DataAccess.Helpers;
using Stores.DataAccess.Models;
using Stores.DataAccess.Repositories;

namespace Stores.BusinessLogic.Services;

public class FaqService : IFaqService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FaqService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<FaqDto> AddAsync(FaqRequest request, CancellationToken cancellationToken)
    {
        var faq = _mapper.Map<Faq>(request);

        _unitOfWork.Faqs.Add(faq);
        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return _mapper.Map<FaqDto>(faq);
    }

    public async Task<string> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var faq = await HelperFunctions.GetOneAsync<Faq>(_unitOfWork.Faqs.GetByIdAsync, id, cancellationToken);

        _unitOfWork.Faqs.Delete(faq);
        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return "The faq has been deleted";
    }

    public async Task<FaqDto> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _mapper.Map<FaqDto>(await HelperFunctions.GetOneAsync<Faq>(_unitOfWork.Faqs.GetByIdAsync, id, cancellationToken));
    }

    public async Task<PageResult<FaqDto>> GetByPageAsync(int page, int pageSize, CancellationToken cancellationToken)
    {
        var faqPageResult = await _unitOfWork.Faqs.GetByPageAsync(page, pageSize, cancellationToken);

        return _mapper.Map<PageResult<FaqDto>>(faqPageResult);
    }

    public async Task<FaqDto> UpdateAsync(int id, FaqRequest request, CancellationToken cancellationToken)
    {
        var faq = await HelperFunctions.GetOneAsync<Faq>(_unitOfWork.Faqs.GetByIdAsync, id, cancellationToken);

        _mapper.Map(request, faq);

        _unitOfWork.Faqs.Update(faq);
        await _unitOfWork.CommitChangesAsync(cancellationToken);

        return _mapper.Map<FaqDto>(faq);
    }
}
