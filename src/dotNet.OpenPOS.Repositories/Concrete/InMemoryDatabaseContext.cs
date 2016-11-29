using dotNet.OpenPOS.Domain.Enums;
using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace dotNet.OpenPOS.Repositories.Concrete
{
    public class InMemoryDatabaseContext : IDatabaseContext
    {
        public InMemoryDatabaseContext()
        {
            Initialize();
        }
        public InMemoryDatabaseContext(string connectionName)
        {
            Initialize();
        }

        #region Containers

        public HashSet<Order> Orders { get; set; }
        public HashSet<Payment> Payments { get; set; }
        public HashSet<Product> Products { get; set; }
        public HashSet<ProductFamily> Families { get; set; }
        public HashSet<Tax> Taxes { get; set; }
        public Account Account { get; set; }
        public HashSet<OrderReference> References { get; set; }

        #endregion

        public void Initialize()
        {
            Account = new Account()
            {
                Id = 0,
                Address = "Plaça del rei",
                City = "Igualada",
                CompanyName = "Company S.A.",
                Phone = "93 123 45 56",
                VatId = "123456789A",
                TIMESTAMP = DateTime.UtcNow
            };

            Taxes = new HashSet<Tax>()
            {
                new Tax() { Id = 0, Code = "0", Value = 0, TIMESTAMP = DateTime.UtcNow },
                new Tax() { Id = 1, Code = "4%", Value = 0.4, TIMESTAMP = DateTime.UtcNow },
                new Tax() { Id = 2, Code = "10%", Value = 0.10, TIMESTAMP = DateTime.UtcNow },
                new Tax() { Id = 3, Code = "21%", Value = 0.21, TIMESTAMP = DateTime.UtcNow },
            };

            Families = new HashSet<ProductFamily>()
            {
                new ProductFamily() { Id = 0, Name = "Principal", ParentId = -1, TIMESTAMP = DateTime.UtcNow },
                new ProductFamily() { Id = 1, Name = "Plats", ParentId = 0, TIMESTAMP = DateTime.UtcNow },
                new ProductFamily() { Id = 2, Name = "Entrepans", ParentId = 0, TIMESTAMP = DateTime.UtcNow },
                new ProductFamily() { Id = 3, Name = "Begudes", ParentId = 0, TIMESTAMP = DateTime.UtcNow },
                new ProductFamily() { Id = 4, Name = "Tapes", ParentId = 0, TIMESTAMP = DateTime.UtcNow },
                new ProductFamily() { Id = 5, Name = "Snacks", ParentId = 0, TIMESTAMP = DateTime.UtcNow },
            };

            Products = new HashSet<Product>()
            {
                new Product() { Id = 0, Code = "COCACOLA", Name = "Coca Cola", BasePrice = 1, Price = 1.10, FamilyId = 3, TaxId = 2, TIMESTAMP = DateTime.UtcNow },
                new Product() { Id = 1, Code = "AIGUA", Name = "Aigua", BasePrice = 1, Price = 1.10, FamilyId = 3, TaxId = 2, TIMESTAMP = DateTime.UtcNow },
                new Product() { Id = 2, Code = "TBRAVES", Name = "Tapa Patates Braves", BasePrice = 2.70, Price = 3, FamilyId = 4, TaxId = 2, TIMESTAMP = DateTime.UtcNow },
                new Product() { Id = 3, Code = "PIPAS", Name = "Pipes Bossa", BasePrice = 1, Price = 1.10, FamilyId = 5, TaxId = 2, TIMESTAMP = DateTime.UtcNow },
                new Product() { Id = 4, Code = "ETRUITA", Name = "ENTREPA TRUITA", BasePrice = 3, Price = 3.5, FamilyId = 2, TaxId = 2, TIMESTAMP = DateTime.UtcNow },
                new Product() { Id = 5, Code = "MORITZ", Name = "CERVESA MORITZ", BasePrice = 0.75, Price = 1.30, FamilyId = 3, TaxId = 3, TIMESTAMP = DateTime.UtcNow },
                new Product() { Id = 6, Code = "PLAT-1", Name = "CARN A LA BRASA", BasePrice = 4, Price = 6, FamilyId = 1, TaxId = 2, TIMESTAMP = DateTime.UtcNow }
            };

            Payments = new HashSet<Payment>()
            {
                new Payment() { Id = 0, OrderId = 0, PaymentType = PaymentType.Cash, Total = 2.20, Value = 5, ReturnValue = 3.80 },
                new Payment() { Id = 1, OrderId = 1, PaymentType = PaymentType.Card, Total = 18.0, Value = 18.0, ReturnValue = 0 },
                new Payment() { Id = 2, OrderId = 2, PaymentType = PaymentType.Bonus, Total = 4.80, Value = 0, ReturnValue = 0 },
                new Payment() { Id = 3, OrderId = 3, PaymentType = PaymentType.Cash, Total = 3, Value = 5, ReturnValue = 2 },
                new Payment() { Id = 4, OrderId = 3, PaymentType = PaymentType.Cash, Total = 3, Value = 10, ReturnValue = 7 },
                new Payment() { Id = 5, OrderId = 3, PaymentType = PaymentType.Cash, Total = 3, Value = 3, ReturnValue = 0 },
            };

            References = new HashSet<OrderReference>()
            {
                new OrderReference() { Id = 0, Reference = 0, TIMESTAMP = DateTime.UtcNow },
                new OrderReference() { Id = 1, Reference = 1, TIMESTAMP = DateTime.UtcNow },
                new OrderReference() { Id = 2, Reference = 2, TIMESTAMP = DateTime.UtcNow },
                new OrderReference() { Id = 3, Reference = 3, TIMESTAMP = DateTime.UtcNow }
            };

            Orders = new HashSet<Order>()
            {
                new Order() {
                    Id = 0,
                    Reference = 0,
                    BaseTotal = 2,
                    CreatedDate = DateTime.UtcNow.AddDays(-21),
                    Name = "Violí",
                    Products = new List<ProductOrder>()
                    {
                        new ProductOrder() { Code = "COCACOLA", Name = "Coca Cola", Quantity = 1, Price = 1.10 },
                        new ProductOrder() { Code = "AIGUA", Name = "Aigua", Quantity = 1, Price = 1.10 }
                    },
                    TaxTotal = 0.2,
                    Total = 2.2,
                    TIMESTAMP = DateTime.UtcNow.AddDays(-21)
                },
                new Order() {
                    Id = 1,
                    Reference = 1,
                    BaseTotal = 12,
                    CreatedDate = DateTime.UtcNow.AddDays(-10),
                    Name = "Joan",
                    Products = new List<ProductOrder>()
                    {
                        new ProductOrder() { Code = "PLAT-1", Name = "CARN A LA BRASA", Quantity = 3, Price = 18 }
                    },
                    TaxTotal = 6,
                    Total = 18.0,
                    TIMESTAMP = DateTime.UtcNow.AddDays(-10)
                },
                new Order() {
                    Id = 2,
                    Reference = 2,
                    BaseTotal = 3.75,
                    CreatedDate = DateTime.UtcNow.AddDays(-2),
                    Name = "Terrassa-1",
                    Products = new List<ProductOrder>()
                    {
                          new ProductOrder() { Code = "ETRUITA", Name = "ENTREPA TRUITA", Quantity = 1, Price = 3.5 },
                          new ProductOrder() { Code = "MORITZ", Name = "CERVESA MORITZ", Quantity = 1, Price = 1.30 }
                    },
                    TaxTotal = 1.05,
                    Total = 4.8,
                    TIMESTAMP = DateTime.UtcNow.AddDays(-2)
                },
                new Order() {
                    Id = 3,
                    Reference = 3,
                    BaseTotal = 8.1,
                    CreatedDate = DateTime.UtcNow,
                    Name = "Taula-3",
                    Products = new List<ProductOrder>()
                    {
                          new ProductOrder() { Code = "TBRAVES", Name = "Tapa Patates Braves", Quantity = 3, Price = 9 },
                    },
                    TaxTotal = 0.9,
                    Total = 9,
                    TIMESTAMP = DateTime.UtcNow
                }
            };
        }
    }
}
