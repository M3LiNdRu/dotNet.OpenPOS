
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Repositories.Interfaces;

namespace dotNet.OpenPOS.Repositories.Concrete
{
    public class ProductFamilyRepository //: Repository<T>, IProductFamilyRepository
    {
        private readonly IDatabaseContext _context;

        public ProductFamilyRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public bool DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductFamily> FindByCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<ProductFamily> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductFamily> FindByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductFamily>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public bool InsertAsync(ProductFamily entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAsync(ProductFamily entity)
        {
            throw new NotImplementedException();
        }
    }
}
