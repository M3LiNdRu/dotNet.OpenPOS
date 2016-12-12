using dotNet.OpenPOS.Domain.Enums;
using dotNet.OpenPOS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> FindPaymentsByOrderIdAsync(int id);
        Task<IEnumerable<Payment>> GetAllPaymentsAsync();
        Task<bool> InsertPaymentAsync(Payment entity);
        Task<bool> UpdatePaymentAsync(Payment entity);
        Task<bool> DeletePaymentAsync(int id);
        Task<IDictionary<PaymentType, string>> GetPaymentTypesAsync();
    }
}
