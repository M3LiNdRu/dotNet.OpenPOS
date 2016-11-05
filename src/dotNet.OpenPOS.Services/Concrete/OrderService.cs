using dotNet.OpenPOS.Repositories.Interfaces;
using dotNet.OpenPOS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet.OpenPOS.Domain.Models;

namespace dotNet.OpenPOS.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<IEnumerable<Order>> GetDailyOrders()
        {
            return _orderRepository.GetDailyOrders();
        }
    }
}
