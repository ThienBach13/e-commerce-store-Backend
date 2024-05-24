using Microsoft.AspNetCore.Mvc;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using Microsoft.AspNetCore.Authorization;
using EcomShop.Core.src.Common;

namespace EcomShop.Controllers.src
{
    [ApiController]
    [Route("api/v1/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryReadDto>>> GetAllCategoriesAsync([FromQuery] QueryOptions options)
        {
            var categories = await _categoryService.GetAllAsync(options);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryReadDto>> GetCategoryByIdAsync([FromRoute] Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(category);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CategoryReadDto>> CreateCategory([FromBody] CategoryCreateDto categoryCreateDto)
        {
            var createdCategory = await _categoryService.CreateAsync(categoryCreateDto);
            // return CreatedAtAction(nameof(GetCategoryByIdAsync), new { id = createdCategory.Id }, createdCategory);
            return Ok(createdCategory);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("{id}")]
        public async Task<ActionResult<CategoryReadDto>> UpdateCategory([FromRoute] Guid id, [FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            var updatedCategory = await _categoryService.UpdateAsync(id, categoryUpdateDto);
            return Ok(updatedCategory);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            var result = await _categoryService.DeleteAsync(id);
            return Ok(result);
        }
    }
}