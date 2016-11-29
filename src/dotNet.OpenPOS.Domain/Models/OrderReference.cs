using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Domain.Models
{
    public class OrderReference : IEntity
    {
        public int Id { get; set; }
        public long Reference { get; set; }
        public DateTime TIMESTAMP { get; set; }
    }
}
