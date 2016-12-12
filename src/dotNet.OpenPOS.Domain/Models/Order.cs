using dotNet.OpenPOS.Domain.Enums;
using System;
using System.Collections.Generic;

namespace dotNet.OpenPOS.Domain.Models
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public long Reference { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductOrder> Products { get; set; }
        public double Total { get; set; }
        public IEnumerable<TaxOrder> Taxes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime TIMESTAMP { get; set; }
        public OrderStatusType Status { get; set; }
    }

    public class ProductOrder
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Base { get; set; }
        public double Price { get; set; }
        public string Tax { get; set; }
    }

    public class TaxOrder
    {
        public string Code { get; set; }
        public double Base { get; set; }
        public double Tax { get; set; }
    }
}
