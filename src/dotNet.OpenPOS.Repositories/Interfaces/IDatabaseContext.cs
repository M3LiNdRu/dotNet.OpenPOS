
using dotNet.OpenPOS.Domain.Models;
using System.Collections.Generic;

namespace dotNet.OpenPOS.Repositories.Interfaces
{
    public interface IDatabaseContext
    {
        HashSet<Order> Orders { get; set; }
        HashSet<Payment> Payments { get; set; }
        HashSet<Product> Products { get; set; }
        HashSet<ProductFamily> Families { get; set; }
        HashSet<Tax> Taxes { get; set; }
        Account Account { get; set; }
    }
}
