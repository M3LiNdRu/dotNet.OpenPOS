
using System;
using dotNet.OpenPOS.Domain.Enums;

namespace dotNet.OpenPOS.Domain.Models
{
    public class Payment : IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public PaymentType PaymentType { get; set; }
        public double Total { get; set; }
        public double Value { get; set; }
        public double ReturnValue { get; set; }
        public DateTime TIMESTAMP { get; set; }
    }
}
