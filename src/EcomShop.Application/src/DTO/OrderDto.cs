using EcomShop.Core.src.Entity;

namespace EcomShop.Application.src.DTO
{
    public class OrderCreateDto
    {
        public int UserId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int AddressId { get; set; }

        public Order CreateOrder(Order order)
        {
            return new Order
            {
                UserId = UserId,
                OrderDate = OrderDate,
                AddressId = AddressId
            };
        }
    }

    public class OrderReadDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int AddressId { get; set; }

        public void Transform(Order order)
        {
            Id = order.Id;
            UserId = order.UserId;
            OrderDate = order.OrderDate;
            AddressId = order.AddressId;
        }

        public static IEnumerable<OrderReadDto> ConvertList(IEnumerable<Order> orders)
        {
            var orderReadDtos = new List<OrderReadDto>();

            foreach (var order in orders)
            {
                var orderReadDto = new OrderReadDto();
                orderReadDto.Transform(order);
                orderReadDtos.Add(orderReadDto);
            }

            return orderReadDtos;
        }
    }

    public class OrderUpdateDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public int AddressId { get; set; }

        public Order UpdateOrder(Order oldOrder)
        {
            oldOrder.UserId = UserId;
            oldOrder.OrderDate = OrderDate;
            oldOrder.AddressId = AddressId;
            return oldOrder;
        }
    }
}