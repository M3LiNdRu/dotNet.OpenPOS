using dotNet.OpenPOS.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<Inventory> GetInventoryAsync();
        Task<IEnumerable<Product>> GetTopProductsAsync(int take);
    }
}
