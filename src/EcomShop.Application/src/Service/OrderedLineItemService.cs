using AutoMapper;
using EcomShop.Application.src.DTO;
using EcomShop.Application.src.ServiceAbstract;
using EcomShop.Core.src.Common;
using EcomShop.Core.src.Entity;
using EcomShop.Core.src.RepoAbstract;

namespace EcomShop.Application.src.Service
{
    public class OrderedLineItemService : BaseService<OrderedLineItem, OrderedLineItemReadDto, OrderedLineItemCreateDto, OrderedLineItemUpdateDto, QueryOptions>, IOrderedLineItemService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderedLineItemService(IBaseRepository<OrderedLineItem, QueryOptions> repository, IOrderRepository orderRepository, IMapper mapper)
            : base(repository, mapper)
        {
            _orderRepository = orderRepository;
        }
        public override async Task<IEnumerable<OrderedLineItemReadDto>> GetAllAsync(QueryOptions queryOptions)
        {
            var orderItems = await _orderRepository.GetListAsync(queryOptions);
            return _mapper.Map<IEnumerable<OrderedLineItemReadDto>>(orderItems);
        }
    }
}