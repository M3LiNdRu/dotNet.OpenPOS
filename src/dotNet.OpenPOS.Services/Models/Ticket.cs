using dotNet.OpenPOS.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace dotNet.OpenPOS.Services.Models
{
    public class Ticket
    {
        public Ticket() { TIMESTAMP = DateTime.UtcNow; }

        public Account AccountDetails { get; set; }     
        public Order OrderDetails { get; set; }
        public IEnumerable<Payment> PaymentDetails { get; set; }
        public IDictionary<string, object> Properties { get; set; }
        public DateTime TIMESTAMP { get; set; }
    }
}
