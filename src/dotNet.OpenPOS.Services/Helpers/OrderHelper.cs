using dotNet.OpenPOS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Services.Helpers
{
    public class OrderHelper
    {
        public OrderHelper() { }

        public void UpdateOrderTotals(Order order)
        {
            double total = 0;
            var taxes = order.Products.Select(p => p.Tax).Distinct();           
            var list = new List<TaxOrder>();

            foreach (var tax in taxes)
            {
                var basePrice = order.Products.Where(p => p.Tax == tax).Sum(p => p.Base * p.Quantity);
                var price = order.Products.Where(p => p.Tax == tax).Sum(p => p.Price * p.Quantity);

                var item = new TaxOrder()
                {
                    Code = tax,
                    Base = Math.Round(basePrice, 2),
                    Tax = Math.Round(price - basePrice, 2)
                };

                total += price;
                list.Add(item);
            }

            order.Total = Math.Round(total,2);
            order.Taxes = list;
        }

        public void UpdateOrderProducts(Order order, IEnumerable<Product> products, IEnumerable<Tax> taxes)
        {
            foreach (var product in order.Products)
            {
                var prod = products.FirstOrDefault(p => p.Id == product.Id);
                var tax = taxes.FirstOrDefault(t => t.Id == prod.TaxId);

                product.Name = prod.Name;
                product.Price = prod.Price;
                product.Code = prod.Code;
                product.Base = prod.BasePrice;
                product.Tax = tax.Code;

            }
        }
    }
}
