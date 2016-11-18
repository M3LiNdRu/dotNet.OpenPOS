using dotNet.OpenPOS.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<Inventory> GetInventoryAsync();
        Task<IEnumerable<Product>> GetTopProductsAsync(int take);
        Task<Product> GetProductAsync(int id);
        Task<bool> CreateProductAsync(Product product);
        Task<bool> EditProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
    }
}
