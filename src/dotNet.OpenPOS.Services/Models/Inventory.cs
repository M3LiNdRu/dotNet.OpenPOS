using dotNet.OpenPOS.Domain.Models;
using System.Collections.Generic;

namespace dotNet.OpenPOS.Services
{
    public class Inventory
    {
        public Inventory()
        {
            ProductFamilies = new List<Inventory>();
        }

        public int Id { get; set; }
        public string FamilyName { get; set; }
        public List<Inventory> ProductFamilies { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
