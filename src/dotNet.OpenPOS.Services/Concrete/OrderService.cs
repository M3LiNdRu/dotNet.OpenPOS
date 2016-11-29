using dotNet.OpenPOS.Repositories.Interfaces;
using dotNet.OpenPOS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Services.Helpers;

namespace dotNet.OpenPOS.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderReferenceRepository _referenceRepository;
        private readonly OrderHelper _orderHelper;

        public OrderService(IOrderRepository orderRepository, IOrderReferenceRepository referenceRepository)
        {
            _orderRepository = orderRepository;
            _referenceRepository = referenceRepository;
            _orderHelper = new OrderHelper();
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

        public async Task<bool> CreateOrderAsync(Order entity)
        {
            //1. Generate Reference
            entity.Reference = await _referenceRepository.GetOrderReferenceAsync();

            //2. Calculate product prices

            //3. Calculate totals
            _orderHelper.UpdateOrderTotals(entity);

            entity.CreatedDate = DateTime.UtcNow;
            entity.TIMESTAMP = DateTime.UtcNow;
            
            //4.Insert
            return await _orderRepository.InsertAsync(entity);
        }

        public async Task<bool> UpdateOrderAsync(Order entity)
        {
            return await _orderRepository.UpdateAsync(entity);
        }
    }
}
