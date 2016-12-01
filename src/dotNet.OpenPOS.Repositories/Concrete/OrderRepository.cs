using dotNet.OpenPOS.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet.OpenPOS.Domain.Models;

namespace dotNet.OpenPOS.Repositories.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDatabaseContext _context;

        public OrderRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Order> FindByIdAsync(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> FindByNameAsync(string name)
        {
            return _context.Orders.Where(o => o.Name == name).OrderByDescending(o => o.CreatedDate);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return _context.Orders;
        }

        public async Task<bool> InsertAsync(Order entity)
        {
            var lastId = _context.Orders.Max(o => o.Id);
            entity.Id = lastId + 1;

            return _context.Orders.Add(entity);
        }

        public async Task<bool> UpdateAsync(Order entity)
        {
            _context.Orders.Remove(entity);

            return _context.Orders.Add(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = _context.Orders.FirstOrDefault(x => x.Id == id);

            return _context.Orders.Remove(entity);
        }

        public async Task<IEnumerable<Order>> GetDailyOrders()
        {
            return _context.Orders.OrderBy(o => o.CreatedDate).Take(10);
        }
    }
}
