using dotNet.OpenPOS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet.OpenPOS.Domain.Models;

namespace dotNet.OpenPOS.Repositories.Concrete
{
    public class TaxRepository : ITaxRepository
    {
        private readonly IDatabaseContext _context;

        public TaxRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tax> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tax>> GetAllAsync()
        {
            return _context.Taxes;
        }

        public Task<bool> InsertAsync(Tax entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Tax entity)
        {
            throw new NotImplementedException();
        }
    }
}
