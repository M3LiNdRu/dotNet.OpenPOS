using dotNet.OpenPOS.Repositories.Interfaces;
using dotNet.OpenPOS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Domain.Enums;

namespace dotNet.OpenPOS.Services.Concrete
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            return await _paymentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Payment>> FindPaymentsByOrderIdAsync(int id)
        {
            return await _paymentRepository.FindByOrderIdAsync(id);
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
        {
            return await _paymentRepository.GetAllAsync();
        }

        public async Task<IDictionary<PaymentType, string>> GetPaymentTypesAsync()
        {
            return _paymentRepository.GetPaymentTypes();
        }

        public async Task<bool> InsertPaymentAsync(Payment entity)
        {
            return await _paymentRepository.InsertAsync(entity);
        }

        public async Task<bool> UpdatePaymentAsync(Payment entity)
        {
            return await _paymentRepository.UpdateAsync(entity);
        }
    }
}
