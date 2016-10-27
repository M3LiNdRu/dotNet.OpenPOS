
using dotNet.OpenPOS.Domain.Models;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> FindByCodeAsync(string code);
    }
}
