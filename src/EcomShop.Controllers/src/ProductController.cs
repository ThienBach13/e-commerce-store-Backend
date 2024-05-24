using Microsoft.AspNetCore.Mvc;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Common;
using Microsoft.AspNetCore.Authorization;

namespace EcomShop.Controllers.src
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> CreateProductAsync([FromBody] ProductCreateDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Invalid request body");
            }

            var createdProduct = await _productService.CreateAsync(productDto);
            if (createdProduct == null)
            {
                return StatusCode(500, "Failed to create product");
            }

            return Ok(createdProduct);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAllProductsAsync([FromQuery] QueryOptions options)
        {
            return Ok(await _productService.GetAllAsync(options));
        }

        [HttpGet("{id}")]
        public async Task<ProductReadDto> GetProductByIdAsync([FromRoute] Guid id)
        {
            return await _productService.GetByIdAsync(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductReadDto>> UpdateProductByIdAsync([FromRoute] Guid id, [FromBody] ProductUpdateDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest("Invalid request body");
            }

            var updatedProduct = await _productService.UpdateAsync(id, updateDto);

            return Ok(updatedProduct);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductByIdAsync([FromRoute] Guid id)
        {
            var result = await _productService.DeleteAsync(id);

            if (!result)
            {
                return NotFound($"Product with ID {id} not found");
            }

            return Ok();
        }

    }
}
