using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomShop.Core.src.Entity;

namespace EcomShop.Core.src.RepoAbstract
{
    public interface ICartRepo
    {
        Task<IEnumerable<ShoppingCartItem>> GetShoppingCartAsync(int userId);
        Task<ShoppingCartItem> UpdateShoppingCartAsync(int userId,ShoppingCartItem item);
        Task<bool> DeleteShoppingCartAsync(int userId);
    }
}