using Microsoft.AspNetCore.Mvc;
using Stores.BusinessLogic.Requests;
using Stores.BusinessLogic.Services;

namespace Stores.Presentation.Controllers;

[ApiController]
[Route("stores/{storeId:int}/policies")]
public class PolicyController : ControllerBase
{
    private readonly IPolicyService _policyService;

    /// <summary>
    /// Initializes a new instance of <see cref="PolicyController"/>
    /// </summary>
    /// <param name="policyService"></param>
    public PolicyController(IPolicyService policyService)
    {
        _policyService = policyService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(int storeId, [FromBody] PolicyRequest request, CancellationToken cancellationToken)
    {
        return Ok(await _policyService.AddAsync(storeId, request, cancellationToken));
    }
}
