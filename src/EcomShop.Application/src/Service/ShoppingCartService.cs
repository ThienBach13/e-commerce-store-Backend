using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;

namespace EcomShop.Application.src.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ICartRepo _cartRepo;
        private readonly IProductService _productService;
        public ShoppingCartService(ICartRepo cartRepo, IProductService productService)
        {
            _cartRepo = cartRepo;
            _productService = productService;
        }

        public async Task<bool> DeleteShoppingCartAsync(int userId)
        {
            return await _cartRepo.DeleteShoppingCartAsync(userId);
        }

        public async Task<IEnumerable<CartItemReadDto>> GetShoppingCartAsync(int userId)
        {
            var getAllItem = await _cartRepo.GetShoppingCartAsync(userId);

            return CartItemReadDto.ConvertList(getAllItem);
        }

        public async Task<CartItemReadDto> UpdateProductInShoppingCartAsync(int userId, ShoppingCartItem updatedProduct)
        {
            var updateItem = await _cartRepo.UpdateShoppingCartAsync(userId, updatedProduct);
            var updateItemDto = new CartItemReadDto();
            updateItemDto.Transform(updateItem);
            return updateItemDto;
        }
    }
}