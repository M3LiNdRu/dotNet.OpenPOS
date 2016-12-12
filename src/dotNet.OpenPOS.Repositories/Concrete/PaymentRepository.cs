using dotNet.OpenPOS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Domain.Enums;

namespace dotNet.OpenPOS.Repositories.Concrete
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDatabaseContext _context;

        public PaymentRepository(IDatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<Payment> FindByIdAsync(int id)
        {
            return _context.Payments.FirstOrDefault(p => p.Id == id);
        }

        public async Task<IEnumerable<Payment>> FindByOrderIdAsync(int id)
        {
            return _context.Payments.Where(p => p.OrderId == id);
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return _context.Payments;
        }

        public async Task<bool> InsertAsync(Payment entity)
        {
            return _context.Payments.Add(entity);
        }

        public async Task<bool> UpdateAsync(Payment entity)
        {
            _context.Payments.Remove(entity);

            return _context.Payments.Add(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = _context.Payments.FirstOrDefault(x => x.Id == id);

            return _context.Payments.Remove(entity);
        }

        public IDictionary<PaymentType, string> GetPaymentTypes()
        {
            var result = new Dictionary<PaymentType, string>()
            {
                { PaymentType.Cash, "Cash" },
                { PaymentType.Card, "Card" },
                { PaymentType.Bonus, "Bonus"}
            };

            return result;
        }
    }
}
