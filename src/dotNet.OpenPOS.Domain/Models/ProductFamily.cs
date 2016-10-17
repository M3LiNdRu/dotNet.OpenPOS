using System;

namespace dotNet.OpenPOS.Domain.Models
{
    public class ProductFamily : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public DateTime TIMESTAMP { get; set; }
    }
}
