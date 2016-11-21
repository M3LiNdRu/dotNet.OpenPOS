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

        public async Task<bool> DeleteOrderAsync(int id)
        {
            return await _orderRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Order>> GetDailyOrdersAsync()
        {
            return await _orderRepository.GetDailyOrders();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.FindByIdAsync(id);
        }

        public async Task<bool> InsertOrderAsync(Order entity)
        {
            return await _orderRepository.InsertAsync(entity);
        }

        public async Task<bool> UpdateOrderAsync(Order entity)
        {
            return await _orderRepository.UpdateAsync(entity);
        }
    }
}
