using EcomShop.Core.src.Entity;

namespace EcomShop.Core.src.RepoAbstract
{
    public interface IShoppingCart
    {
        Task<ShoppingCart> GetShoppingCartAsync(int userId);
        Task<ShoppingCart> UpdateShoppingCartAsync(ShoppingCartItem shoppingCartItem);
        Task<bool> EmptyShoppingCartAsync(int userId);
    }
}