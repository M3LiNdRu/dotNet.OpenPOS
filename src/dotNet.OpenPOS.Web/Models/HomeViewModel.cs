using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Services;
using System.Collections.Generic;

namespace dotNet.OpenPOS.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Order> LastDailyOrders { get; set; }
        public Inventory Products { get; set; }
        public IEnumerable<Product> TopProducts { get; set; }
        public Account AccountInfo { get; set; }
    }
}
