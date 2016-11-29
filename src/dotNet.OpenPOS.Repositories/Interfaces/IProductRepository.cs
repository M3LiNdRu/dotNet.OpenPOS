
using dotNet.OpenPOS.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> FindByCodeAsync(string code);
        Task<Product> FindByNameAsync(string name);
        Task<IEnumerable<Product>> FindByIdAsync(IEnumerable<int> ids);
    }
}
