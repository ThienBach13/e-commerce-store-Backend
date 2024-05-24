using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcomShop.Controllers.src
{
    [ApiController]
    [Route("api/v1/product/productImages")]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct([FromQuery] QueryOptions options)
        {
            return Ok(await _productImageService.GetAllAsync(options));
        }

        [HttpGet("{productImageId}")]
        public async Task<IActionResult> GetProductImageByIdAsync([FromRoute] Guid productImageId)
        {
            return Ok(await _productImageService.GetByIdAsync(productImageId));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateImage(ProductImageCreateDto img)
        {
            return Ok(await _productImageService.CreateAsync(img));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{productImageId}")]
        public async Task<IActionResult> UpdateProductImageByIdAsync([FromRoute] Guid productImageId, [FromBody] ProductImageUpdateDto productImageUpdateDto)
        {
            return Ok(await _productImageService.UpdateAsync(productImageId, productImageUpdateDto));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{productImageId}")]
        public async Task<IActionResult> DeleteProductByIdAsync([FromRoute] Guid productImageId)
        {
            return Ok(await _productImageService.DeleteAsync(productImageId));
        }

    }
}