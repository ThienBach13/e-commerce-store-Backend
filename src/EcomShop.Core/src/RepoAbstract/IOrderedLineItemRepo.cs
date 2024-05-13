using EcomShop.Core.src.Entity;

namespace EcomShop.Core.src.RepoAbstract
{
    public interface IOrderedLineItemRepo
    {
        // -- function to create order line item to database
        Task<OrderedLineItem> CreateOrderedLineItemAsync();
        // -- function to delete 1 item in a order by order_line_id
        Task<OrderedLineItem> DeleteOneItemInOrderedLineItemByIdAsync(int id);
    }
}