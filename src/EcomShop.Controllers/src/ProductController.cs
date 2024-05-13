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

            var createdProduct = await _productService.CreateProductAsync(productDto);
            if (createdProduct == null)
            {
                return StatusCode(500, "Failed to create product");
            }

            return Ok(createdProduct);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductReadDto>> GetAllProductsAsync([FromQuery] ProductQueryOptions options)
        {
            var products = await _productService.GetAllProductsAsync(options);
            return products;
        }

        [HttpGet("{id:int}")]
        public async Task<ProductReadDto> GetProductByIdAsync([FromRoute] int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return product;
        }

        // [HttpGet]
        // public async Task<IEnumerable<ProductReadDto>> GetProductsByPaginationAsync([FromQuery] QueryPagination query)
        // {
        //     var products = await _productService.GetProductsByPaginationAsync(query.offset, query.limit);
        //     return products;
        // }

        // [HttpGet]
        // public async Task<IEnumerable<ProductReadDto>> GetProductsByPriceRangeAsync([FromQuery] decimal priceMin, [FromQuery] decimal priceMax)
        // {
        //     var products = await _productService.GetProductsByPriceRangeAsync(priceMin, priceMax);
        //     return products;
        // }

        // [HttpGet]
        // public async Task<IEnumerable<ProductReadDto>> GetProductsByCategoriesAsync([FromQuery] int categoryId)
        // {
        //     var products = await _productService.GetProductsByCategoriesAsync(categoryId);
        //     return products;
        // }

        // [HttpGet]
        // public async Task<IEnumerable<ProductReadDto>> SearchProductsByNameAsync([FromQuery] string searchKey)
        // {
        //     var products = await _productService.SearchProductsByNameAsync(searchKey);
        //     return products;
        // }

        // [HttpGet]
        // public async Task<IEnumerable<ProductReadDto>> SortProductsByPriceAsync([FromQuery] string sortOrder)
        // {
        //     var products = await _productService.SortProductsByPriceAsync(sortOrder);
        //     return products;
        // }

        // [HttpGet]
        // public async Task<IEnumerable<ProductReadDto>> SortProductsByNameAsync([FromQuery] string sortOrder)
        // {
        //     var products = await _productService.SortProductsByNameAsync(sortOrder);
        //     return products;
        // }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductReadDto>> UpdateProductByIdAsync([FromRoute] int id, [FromBody] ProductUpdateDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest("Invalid request body");
            }

            updateDto.Id = id;

            var updatedProduct = await _productService.UpdateProductByIdAsync(updateDto);

            return Ok(updatedProduct);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductByIdAsync([FromRoute] int id)
        {
            var result = await _productService.DeleteProductByIdAsync(id);

            if (!result)
            {
                return NotFound($"Product with ID {id} not found");
            }

            return NoContent();
        }
       
    }
}
