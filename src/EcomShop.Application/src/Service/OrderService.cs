using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;

namespace EcomShop.Application.src.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<OrderReadDto> CreateOrderAsync(OrderCreateDto orderDto)
        {
            var order = orderDto.CreateOrder(new Order());
            var createdOrder = await _orderRepo.CreateOrderAsync(order);
            var orderReadDto = new OrderReadDto();
            orderReadDto.Transform(createdOrder);
            return orderReadDto;
        }

        public async Task<bool> DeleteOrderByIdAsync(int id)
        {
            return await _orderRepo.DeleteOrderByIdAsync(id);
        }

        public async Task<IEnumerable<OrderReadDto>> GetAllOrdersAsync(OrderQueryOptions options)
        {
            var orders = await _orderRepo.GetAllOrdersAsync(options);
            return OrderReadDto.ConvertList(orders);
        }

        public async Task<OrderReadDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepo.GetOrderByIdAsync(id);
            var orderReadDto = new OrderReadDto();
            orderReadDto.Transform(order);
            return orderReadDto;
        }

        public async Task<OrderReadDto> GetOrderByCustomerIdAsync(int customerId)
        {
            var order = await _orderRepo.GetOrderByCustomerIdAsync(customerId);
            var orderReadDto = new OrderReadDto();
            orderReadDto.Transform(order);
            return orderReadDto;
        }
    }
}
