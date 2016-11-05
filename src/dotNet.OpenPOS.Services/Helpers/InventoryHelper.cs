using dotNet.OpenPOS.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace dotNet.OpenPOS.Services.Helpers
{
    public static class InventoryHelper
    {
        private const int FamilyParentId = 0;

        public static Inventory BuildInventory(IEnumerable<ProductFamily> families, IEnumerable<Product> products)
        {
            var result = new Inventory();
            //TODO: Recursive algorithm

            return result;
        }
    }
}
