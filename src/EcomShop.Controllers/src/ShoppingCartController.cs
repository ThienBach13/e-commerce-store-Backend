using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcomShop.Controllers.src
{
    [ApiController]
    [Route("api/v1/cart")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<CartItemReadDto>> GetAllItemsInCartAsync()
        {
            string customerId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value; ;
            int idValue = int.Parse(customerId);

            var listItem = await _shoppingCartService.GetShoppingCartAsync(idValue);
            if (listItem == null)
            {
                return NotFound("The list item is empty");
            }
            return Ok(listItem);
        }
        [Authorize]
        [HttpPatch]
        public async Task<ActionResult<CategoryReadDto>> UpdateProductQuantity([FromBody] ShoppingCartItem updatedProduct)
        {
            if (updatedProduct == null)
            {
                return BadRequest("Bad requestbody");
            }
            int userId = 0;
            var rs = await _shoppingCartService.UpdateProductInShoppingCartAsync(userId, updatedProduct);
            if (rs == null)
            {
                return NotFound($"The product {updatedProduct.Id} was not found");
            }
            return Ok(rs);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> DeleteAllProductInCart()
        {
            string customerId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value; ;
            int idValue = int.Parse(customerId);
            var rs = await _shoppingCartService.DeleteShoppingCartAsync(idValue);
            if (!rs)
            {
                return NotFound("The list is empty");
            }
            return Ok();
        }
    }
}