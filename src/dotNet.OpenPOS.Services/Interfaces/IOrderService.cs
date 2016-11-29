using dotNet.OpenPOS.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetDailyOrdersAsync();
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        Task<Order> GetOrderByIdAsync(int id);
        Task<bool> CreateOrderAsync(Order intenty);
        Task<bool> UpdateOrderAsync(Order identity);
        Task<bool> DeleteOrderAsync(int id);

    }
}
