using dotNet.OpenPOS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotNet.OpenPOS.Domain.Models;

namespace dotNet.OpenPOS.Repositories.Concrete
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IDatabaseContext _context;

        public AccountRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAsync()
        {
            return _context.Account;
        }

        public async Task<bool> InsertAsync(Account entity)
        {
            _context.Account = entity;

            return true;
        }

        public async Task<bool> UpdateAsync(Account entity)
        {
            _context.Account = entity;

            return true;
        }

        public async Task<bool> DeleteAsync()
        {
            _context.Account = null;

            return true;
        }
    }
}
