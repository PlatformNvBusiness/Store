using Microsoft.AspNetCore.Mvc;
using Stores.BusinessLogic.Requests;
using Stores.BusinessLogic.Services;

namespace Stores.Presentation.Controllers;

/// <summary>
/// The category type controller
/// </summary>
[ApiController]
[Route("categorytypes")]
public class CategoryTypeController : ControllerBase
{
    private readonly ICategoryTypeService _categoryTypeService;

    /// <summary>
    /// Initializes a new instance of <see cref="CategoryTypeController"/>
    /// </summary>
    /// <param name="categoryTypeService">The categoryType service responsible for adding, updating and deleting 
    /// the categories types from the database</param>
    public CategoryTypeController(ICategoryTypeService categoryTypeService)
    {
        _categoryTypeService = categoryTypeService;
    }

    /// <summary>
    /// Add a new category type
    /// </summary>
    /// <param name="categoryRequest"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddAsync([FromBody] CategoryTypeRequest categoryRequest, CancellationToken cancellation)
    {
        return Created(nameof(AddAsync), await _categoryTypeService.AddAsync(categoryRequest, cancellation));
    }

    /// <summary>
    /// Update a category
    /// </summary>
    /// <param name="id"></param>
    /// <param name="categoryRequest"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] CategoryTypeRequest categoryRequest, CancellationToken cancellation)
    {
        return Ok(await _categoryTypeService.UpdateAsync(id, categoryRequest, cancellation));
    }

    /// <summary>
    /// Delete a category type
    /// </summary>
    /// <param name="id"></param>
    /// <param name="categoryRequest"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAsync(int id, [FromBody] CategoryTypeRequest categoryRequest, CancellationToken cancellation)
    {
        return Ok(await _categoryTypeService.DeleteAsync(id, cancellation));
    }

    /// <summary>
    /// Get the categories by pages
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCategoriesAsync([FromHeader] int page, [FromHeader] int size, CancellationToken cancellation)
    {
        return Ok(await _categoryTypeService.GetCategoriesTypeAsync(page, size, cancellation));
    }
}
