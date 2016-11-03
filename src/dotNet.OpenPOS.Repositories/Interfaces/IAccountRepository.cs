using dotNet.OpenPOS.Domain.Models;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task<Account> GetAsync();
        Task<bool> InsertAsync(Account entity);
        Task<bool> UpdateAsync(Account entity);
        Task<bool> DeleteAsync();

    }
}
