using Microsoft.AspNetCore.Mvc;
using Stores.BusinessLogic.Requests;
using Stores.BusinessLogic.Services;

namespace Stores.Presentation.Controllers;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("stores/{storeId}/items/{itemId}/itemvariations")]
public class ItemVariationController : ControllerBase
{
    private readonly IItemVariationService _itemVariationService;

    public ItemVariationController(IItemVariationService itemVariationService)
    {
        _itemVariationService = itemVariationService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(int storeId, int itemId, [FromBody] ItemVariationRequest request, CancellationToken cancellationToken)
    {
        return Created(nameof(AddAsync), _itemVariationService.AddAsync(request, cancellationToken));
    }

    [HttpPut("{itemVariationId:int}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAsync(int itemVariationId, ItemVariationRequest request, CancellationToken cancellation)
    {
        return Ok(_itemVariationService.UpdateAsync(itemVariationId, request, cancellation));
    }

    [HttpDelete("{itemVariationId:int}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAsync(int itemVariationId, CancellationToken cancellation)
    {
        return Ok(_itemVariationService.DeleteAsync(itemVariationId, cancellation));
    }
}
