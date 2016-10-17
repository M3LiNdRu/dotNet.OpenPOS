using System;
using System.Collections.Generic;

namespace dotNet.OpenPOS.Domain.Models
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public double BaseTotal { get; set; }
        public double TaxTotal { get; set; }
        public double Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime TIMESTAMP { get; set; }
    }
}
