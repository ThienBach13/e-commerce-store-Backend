using AutoMapper;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;

namespace EcomShop.Application.src.Service
{
    public class OrderService : BaseService<Order, OrderReadDto, OrderCreateDto, OrderUpdateDto, QueryOptions>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository,
        IUserRepository userRepository, IProductRepository productRepository,
        IMapper mapper)
            : base(orderRepository, mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<OrderReadDto>> GetOrdersByUserIdAsync(Guid userId)
        {
            var foundUser = await _userRepository.GetByIdAsync(userId);
            if (foundUser is not null)
            {
                var result = _orderRepository.GetOrderByCustomerIdAsync(userId);
                return _mapper.Map<IEnumerable<OrderReadDto>>(result);
            }
            else
            {
                throw new NotSupportedException($"Unable to find {userId}");
            }
        }
    }
}
