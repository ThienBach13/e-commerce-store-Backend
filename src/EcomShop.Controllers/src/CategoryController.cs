using Microsoft.AspNetCore.Mvc;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IEnumerable<CategoryReadDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return categories;
        }

        [HttpGet("{id:int}")]
        public async Task<CategoryReadDto> GetCategoryByIdAsync([FromRoute] int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            return category;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CategoryReadDto>> CreateCategory([FromBody] CategoryCreateDto categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("Invalid request body");
            }

            var createdCategory = await _categoryService.CreateCategoryAsync(categoryDto);
            if (createdCategory == null)
            {
                return StatusCode(500, "Failed to create category");
            }

            return createdCategory;
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("{id:int}")]
        public async Task<ActionResult<CategoryReadDto>> UpdateCategory([FromRoute] int id, [FromBody] CategoryUpdateDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest("Invalid request body");
            }

            updateDto.Id = id;

            var updatedCategory = await _categoryService.UpdateCategoryByIdAsync(updateDto);

            return Ok(updatedCategory);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var result = await _categoryService.DeleteCategoryByIdAsync(id);

            if (!result)
            {
                return NotFound($"Category with ID {id} not found");
            }

            return NoContent();
        }
    }
}