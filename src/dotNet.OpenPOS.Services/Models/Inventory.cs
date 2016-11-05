using dotNet.OpenPOS.Domain.Models;
using System.Collections.Generic;

namespace dotNet.OpenPOS.Services
{
    public class Inventory
    {
        public string FamilyName { get; set; }
        public IEnumerable<Inventory> ProductFamilies { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
