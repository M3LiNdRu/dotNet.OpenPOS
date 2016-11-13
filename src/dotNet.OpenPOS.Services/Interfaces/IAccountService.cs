
using dotNet.OpenPOS.Domain.Models;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Services.Interfaces
{
    public interface IAccountService 
    {
        Task<Account> GetAccountAsync();
        Task<bool> InsertAsync(Account entity);


    }
}
