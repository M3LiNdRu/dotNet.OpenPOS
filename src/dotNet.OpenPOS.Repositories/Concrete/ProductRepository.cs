using dotNet.OpenPOS.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet.OpenPOS.Domain.Models;
using System;

namespace dotNet.OpenPOS.Repositories.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDatabaseContext _context;

        public ProductRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Product> FindByNameAsync(string name)
        {
            return _context.Products.FirstOrDefault(p => p.Name == name);
        }

        public async Task<Product> FindByCodeAsync(string code)
        {
            return _context.Products.FirstOrDefault(p => p.Code == code);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return _context.Products;
        }

        public async Task<bool> InsertAsync(Product entity)
        {
            return _context.Products.Add(entity);
        }

        public async Task<bool> UpdateAsync(Product entity)
        {
            _context.Products.Remove(entity);

            return _context.Products.Add(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = _context.Products.FirstOrDefault(x => x.Id == id);

            return _context.Products.Remove(entity);
        }

        public async Task<IEnumerable<Product>> FindByIdAsync(IEnumerable<int> ids)
        {
            var entities = _context.Products.Where(p => ids.Contains(p.Id));

            return entities;
        }
    }
}
