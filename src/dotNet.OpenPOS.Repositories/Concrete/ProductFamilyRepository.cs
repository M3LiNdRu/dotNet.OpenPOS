
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Repositories.Interfaces;

namespace dotNet.OpenPOS.Repositories.Concrete
{
    public class ProductFamilyRepository : IProductFamilyRepository
    {
        private readonly IDatabaseContext _context;

        public ProductFamilyRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<ProductFamily> FindByIdAsync(int id)
        {
            return _context.Families.Where(f => f.Id == id).FirstOrDefault();
        }

        public async Task<ProductFamily> FindByNameAsync(string name)
        {
            return _context.Families.Where(f => f.Name == name).FirstOrDefault();
        }

        public async Task<IEnumerable<ProductFamily>> GetAllAsync()
        {
            return _context.Families;
        }

        public async Task<bool> InsertAsync(ProductFamily entity)
        {
            return _context.Families.Add(entity);
        }

        public async Task<bool> UpdateAsync(ProductFamily entity)
        {
            _context.Families.Remove(entity);

            return _context.Families.Add(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = _context.Families.FirstOrDefault(x => x.Id == id);

            return _context.Families.Remove(entity);
        }
    }
}
