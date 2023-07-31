using Microsoft.AspNetCore.Mvc;
using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Requests;
using Stores.BusinessLogic.Services;

namespace Stores.Presentation.Controllers;

/// <summary>
/// The store controller
/// </summary>
[ApiController]
[Route("stores")]
public class StoreController : ControllerBase
{
    private readonly IStoreService _storeService;

    /// <summary>
    /// Initializes a new instance of <see cref="StoreController"/>
    /// </summary>
    /// <param name="storeService"></param>
    public StoreController(IStoreService storeService)
    {
        _storeService = storeService;
    }

    /// <summary>
    /// Add the store
    /// </summary>
    /// <param name="storeRequest"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddAsync([FromBody] StoreRequest storeRequest, CancellationToken cancellation)
    {
        return Created("stores/", await _storeService.AddAsync(storeRequest, cancellation));
    }

    /// <summary>
    /// Update the store
    /// </summary>
    /// <param name="id"></param>
    /// <param name="storeRequest"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody]StoreRequest storeRequest, CancellationToken cancellation)
    {
        return Ok(await _storeService.UpdateAsync(id, storeRequest, cancellation));
    }

    /// <summary>
    /// Delete the store
    /// </summary>
    /// <param name="id"></param>
    /// <param name="userId"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<StoreDto>> DeleteAsync(int id,[FromHeader] int userId, CancellationToken cancellation)
    {
        return Ok(await _storeService.DeleteAsync(id, userId, cancellation));
    }

    /// <summary>
    /// Get The store by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellation)
    {
        return Ok(await _storeService.GetByIdAsync(id, cancellation));
    }

    /// <summary>
    /// Get The store by page
    /// </summary>
    /// <param name="size"></param>
    /// <param name="pageNumber"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByPageAsync([FromHeader]int size, [FromHeader]int pageNumber, CancellationToken cancellation)
    {
        return Ok(await _storeService.GetStoresAsync(size, pageNumber, cancellation));
    }
}
