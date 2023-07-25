using Microsoft.AspNetCore.Mvc;
using Stores.BusinessLogic.DTO_s;
using Stores.BusinessLogic.Requests;
using Stores.BusinessLogic.Services;
using Stores.BusinessLogic.Helpers;

namespace Stores.Presentation.Controllers;

[ApiController]
[Route("stores")]
public class StoreController : ControllerBase
{
    private readonly IStoreService _storeService;

    public StoreController(IStoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<StoreDto>> AddAsync([FromBody] StoreRequest storeRequest, CancellationToken cancellation)
    {
        return Created("stores/", await _storeService.AddAsync(storeRequest, cancellation));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<StoreDto>> UpdateAsync(int id, [FromBody]StoreRequest storeRequest, CancellationToken cancellation)
    {
        return Ok(await _storeService.UpdateAsync(id, storeRequest, cancellation));
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<StoreDto>> DeleteAsync(int id,[FromHeader] int userId, CancellationToken cancellation)
    {
        return Ok(await _storeService.DeleteAsync(id, userId, cancellation));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<StoreDto>> GetByIdAsync(int id, CancellationToken cancellation)
    {
        return Ok(await _storeService.GetByIdAsync(id, cancellation));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PageResult<StoreDto>>> GetByPageAsync([FromHeader]int size, [FromHeader]int pageNumber, CancellationToken cancellation)
    {
        return Ok(await _storeService.GetStoresAsync(size, pageNumber, cancellation));
    }
}
