using Microsoft.AspNetCore.Mvc;
using Stores.BusinessLogic.Requests;
using Stores.BusinessLogic.Services;

namespace Stores.Presentation.Controllers
{
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAsync([FromBody] CategoryRequest categoryRequest, CancellationToken cancellation)
        {
            return Created(nameof(AddAsync), await _categoryService.AddAsync(categoryRequest, cancellation));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CategoryRequest categoryRequest, CancellationToken cancellation)
        {
            return Ok(await _categoryService.UpdateAsync(id, categoryRequest, cancellation));
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] CategoryRequest categoryRequest, CancellationToken cancellation)
        {
            return Ok(await _categoryService.DeleteAsync(id, cancellation));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategoriesAsync(CancellationToken cancellation)
        {
            return Ok(await _categoryService.GetCategoriesAsync(cancellation));
        }
    }
}
