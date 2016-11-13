using dotNet.OpenPOS.Services.Interfaces;
using System;
using System.Threading.Tasks;
using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Repositories.Interfaces;

namespace dotNet.OpenPOS.Services.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> GetAccountAsync()
        {
            return await _accountRepository.GetAsync();
        }

        public async Task<bool> InsertAsync(Account entity)
        {
            return await _accountRepository.InsertAsync(entity);
        }
    }
}
