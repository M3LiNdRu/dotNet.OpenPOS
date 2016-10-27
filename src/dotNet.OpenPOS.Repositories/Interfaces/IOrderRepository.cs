using dotNet.OpenPOS.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> FindByNameAsync(string name);
    }
}
