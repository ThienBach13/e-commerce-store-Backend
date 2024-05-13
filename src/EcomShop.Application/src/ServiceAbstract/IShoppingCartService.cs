using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomShop.Application.src.DTO;
using EcomShop.Core.src.Entity;

namespace EcomShop.Application.src.ServiceAbstract
{
    public interface IShoppingCartService
    {
        Task<IEnumerable<CartItemReadDto>> GetShoppingCartAsync(int userId);
        Task<CartItemReadDto> UpdateProductInShoppingCartAsync(int userId, ShoppingCartItem updatedProduct);
        Task<bool> DeleteShoppingCartAsync(int userId);
    }
}