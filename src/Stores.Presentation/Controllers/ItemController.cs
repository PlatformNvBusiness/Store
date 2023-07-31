using Microsoft.AspNetCore.Mvc;
using Stores.BusinessLogic.Requests;
using Stores.BusinessLogic.Services;

namespace Stores.Presentation.Controllers;

/// <summary>
/// The Item contrllers
/// </summary>
[ApiController]
[Route("stores/{storeId:int}/items")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    /// <summary>
    /// Initializes a new instance of <see cref="ItemController"/>
    /// </summary>
    /// <param name="itemService"></param>
    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    /// <summary>
    /// Add a new item
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="request"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddAsync([FromRoute] int storeId, ItemRequest request, CancellationToken cancellation)
    {
        return Created("items", await _itemService.AddAsync(storeId, request, cancellation));
    }

    /// <summary>
    /// Get all item of the store by his id
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAsync(int storeId, CancellationToken cancellation)
    {
        return Ok(await _itemService.GetAllAsync(storeId, cancellation));
    }

    /// <summary>
    /// Update the item
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="itemId"></param>
    /// <param name="item"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPut("itemId:int")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAsync(int storeId, int itemId, [FromBody] ItemRequest item, CancellationToken cancellation)
    {
        return Ok(await _itemService.UpdateAsync(storeId, itemId, item, cancellation));
    }

    /// <summary>
    /// Delete an item by the id
    /// </summary>
    /// <param name="storeId"></param>
    /// <param name="itemId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpDelete("itemId:int")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAsync(int storeId, int itemId, CancellationToken cancellation)
    {
        return Ok(await _itemService.DeleteAsync(storeId, itemId, cancellation));
    }
}
