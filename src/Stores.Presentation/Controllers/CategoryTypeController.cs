using Microsoft.AspNetCore.Mvc;
using Stores.BusinessLogic.Requests;
using Stores.BusinessLogic.Services;

namespace Stores.Presentation.Controllers
{
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAsync([FromBody] CategoryTypeRequest categoryRequest, CancellationToken cancellation)
        {
            return Created(nameof(AddAsync), await _categoryTypeService.AddAsync(categoryRequest, cancellation));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CategoryTypeRequest categoryRequest, CancellationToken cancellation)
        {
            return Ok(await _categoryTypeService.UpdateAsync(id, categoryRequest, cancellation));
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id, [FromBody] CategoryTypeRequest categoryRequest, CancellationToken cancellation)
        {
            return Ok(await _categoryTypeService.DeleteAsync(id, cancellation));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCategoriesAsync(CancellationToken cancellation)
        {
            return Ok(await _categoryTypeService.GetCategoriesTypeAsync(cancellation));
        }
    }
}
