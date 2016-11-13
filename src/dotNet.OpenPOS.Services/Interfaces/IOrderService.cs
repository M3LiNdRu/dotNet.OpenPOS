using dotNet.OpenPOS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetDailyOrdersAsync();
    }
}
