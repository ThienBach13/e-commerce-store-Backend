using EcomShop.Application.src.DTO;
using EcomShop.Core.src.Common;

namespace EcomShop.Application.src.ServiceAbstract
{
    public interface IOrderService : IBaseService<OrderReadDto, OrderCreateDto, OrderUpdateDto, QueryOptions>
    {
        Task<IEnumerable<OrderReadDto>> GetOrdersByUserIdAsync(Guid userId);
    }
}