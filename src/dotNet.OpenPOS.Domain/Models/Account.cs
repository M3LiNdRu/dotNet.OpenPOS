using System;


namespace dotNet.OpenPOS.Domain.Models
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string VatId { get; set; }
        public DateTime TIMESTAMP { get; set; }
    }
}
