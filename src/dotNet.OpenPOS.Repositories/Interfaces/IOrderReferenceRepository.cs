using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Repositories.Interfaces
{
    public interface IOrderReferenceRepository
    {
        Task<long> GetOrderReferenceAsync();
    }
}
