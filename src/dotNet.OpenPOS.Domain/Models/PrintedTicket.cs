using System;

namespace dotNet.OpenPOS.Domain.Models
{
    public class PrintedTicket : IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Ticket { get; set; }
        public DateTime TIMESTAMP { get; set; }
    }
}
