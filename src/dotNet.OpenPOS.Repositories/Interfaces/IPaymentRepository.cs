using dotNet.OpenPOS.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Repositories.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<IEnumerable<Payment>> FindByOrderIdAsync(int id);
    }
}
