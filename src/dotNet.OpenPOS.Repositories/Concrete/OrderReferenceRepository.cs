using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Repositories.Concrete
{
    public class OrderReferenceRepository : IOrderReferenceRepository
    {
        private readonly IDatabaseContext _context;

        public OrderReferenceRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<long> GetOrderReferenceAsync()
        {
            var last = _context.References.Last();
            var result = new OrderReference();

            if (last != null)
            {
                result = new OrderReference()
                {
                    Id = last.Id + 1,
                    Reference = last.Reference + 1,
                    TIMESTAMP = DateTime.UtcNow
                };          
            }
            else
            {
                result = new OrderReference() { Id = 0, Reference = 0, TIMESTAMP = DateTime.UtcNow };
            }

            _context.References.Add(result);
            return result.Reference;
        }
    }
}
