using Microsoft.AspNetCore.Mvc;
using Stores.BusinessLogic.Requests;
using Stores.BusinessLogic.Services;

namespace Stores.Presentation.Controllers;

/// <summary>
/// The category controller
/// </summary>
[ApiController]
[Route("categories")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    /// <summary>
    /// Initializes a new instance of <see cref="CategoryController"/>
    /// </summary>
    /// <param name="categoryService">The category service responsible for adding, updating and deleting 
    /// the categories from the database</param>
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    /// <summary>
    /// Add a new category
    /// </summary>
    /// <param name="categoryRequest"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddAsync([FromBody] CategoryRequest categoryRequest, CancellationToken cancellation)
    {
        return Created(nameof(AddAsync), await _categoryService.AddAsync(categoryRequest, cancellation));
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
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] CategoryRequest categoryRequest, CancellationToken cancellation)
    {
        return Ok(await _categoryService.UpdateAsync(id, categoryRequest, cancellation));
    }

    /// <summary>
    /// Delete a category
    /// </summary>
    /// <param name="id"></param>
    /// <param name="categoryRequest"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAsync(int id, [FromBody] CategoryRequest categoryRequest, CancellationToken cancellation)
    {
        return Ok(await _categoryService.DeleteAsync(id, cancellation));
    }

    /// <summary>
    /// Get the categories by page
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCategoriesAsync([FromHeader]int page, [FromHeader]int size, CancellationToken cancellation)
    {
        return Ok(await _categoryService.GetCategoriesAsync(page, size, cancellation));
    }
}
