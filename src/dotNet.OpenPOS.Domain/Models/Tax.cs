using System;

namespace dotNet.OpenPOS.Domain.Models
{
    public class Tax : IEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public double Value { get; set; }
        public DateTime TIMESTAMP { get; set; }
    }
}
