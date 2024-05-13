using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomShop.Api.src.Persistence;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;
using Microsoft.EntityFrameworkCore;

namespace EcomShop.Api.repo
{
    public class ShoppingCartRepository : ICartRepo
    {
        private readonly EcomShopDbContext _dbContext;
        public ShoppingCartRepository(EcomShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> DeleteShoppingCartAsync(int userId)
        {
            // Retrieve shopping cart items associated with the user ID
            var shoppingCartItems = await (from item in _dbContext.ShoppingCartItems
                                           join cart in _dbContext.ShoppingCarts
                                           on item.ShoppingCartId equals cart.Id
                                           where cart.UserId == userId
                                           select item).ToListAsync();

            if (shoppingCartItems.Any())
            {
                // Remove the shopping cart items from the DbContext
                _dbContext.ShoppingCartItems.RemoveRange(shoppingCartItems);

                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                return true; // Shopping cart items successfully deleted
            }
            else
            {
                return false; // No shopping cart items found for the user
            }
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetShoppingCartAsync(int userId)
        {
            var shoppingCartItems = await (from item in _dbContext.ShoppingCartItems
                                           join cart in _dbContext.ShoppingCarts
                                           on item.ShoppingCartId equals cart.Id
                                           where cart.UserId == userId
                                           select item).ToListAsync();
            return shoppingCartItems;
        }

        public async Task<ShoppingCartItem> UpdateShoppingCartAsync(int userId, ShoppingCartItem item)
        {
            // Find the existing shopping cart item associated with the provided user ID and item ID
            var existingItem = await _dbContext.ShoppingCartItems.FirstOrDefaultAsync(i => i.Id == userId && i.Id == item.Id);

            if (existingItem != null)
            {
                // Update the existing item with the properties of the new item
                existingItem.ProductId = item.ProductId;
                existingItem.Quantity = item.Quantity;

                // Save changes to the database
                await _dbContext.SaveChangesAsync();

                return existingItem; // Return the updated shopping cart item
            }
            else
            {
                return null; // Shopping cart item not found
            }
        }
    }
}