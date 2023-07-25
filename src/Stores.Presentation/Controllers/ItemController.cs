using Microsoft.AspNetCore.Mvc;
using Stores.BusinessLogic.Requests;
using Stores.BusinessLogic.Services;

namespace Stores.Presentation.Controllers;

[ApiController]
[Route("stores/{storeId:int}/items")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddAsync([FromRoute] int storeId, ItemRequest request, CancellationToken cancellation)
    {
        return Created("items", await _itemService.AddAsync(storeId, request, cancellation));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAsync(int storeId, CancellationToken cancellation)
    {
        return Ok(await _itemService.GetAllAsync(storeId, cancellation));
    }

    [HttpPut("itemId:int")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAsync(int storeId, int itemId, [FromBody] ItemRequest item, CancellationToken cancellation)
    {
        return Ok(await _itemService.UpdateAsync(storeId, itemId, item, cancellation));
    }
}
