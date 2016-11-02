using System;

namespace dotNet.OpenPOS.Domain.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double BasePrice { get; set; }      
        public double Price { get; set; }
        public int Sales { get; set; }
        public int TaxId { get; set; }
        public int FamilyId { get; set; }
        public DateTime TIMESTAMP { get; set; }
    }
}
