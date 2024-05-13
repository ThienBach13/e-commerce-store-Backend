using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcomShop.Core.src.Entity;

namespace EcomShop.Application.src.DTO
{
    public class CartItemReadDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public void Transform(ShoppingCartItem cartItem)
        {
            Id = cartItem.Id;
            ProductId = cartItem.ProductId;
            Quantity = cartItem.Quantity;
        }

        public static IEnumerable<CartItemReadDto> ConvertList(IEnumerable<ShoppingCartItem> listCartItems)
        {
            var listCartItemDto = new List<CartItemReadDto>();
            foreach (var item in listCartItems)
            {
                var cartItemReadDto = new CartItemReadDto();
                cartItemReadDto.Transform(item);
                listCartItemDto.Add(cartItemReadDto);
            }
            return listCartItemDto;
        }
    }
}