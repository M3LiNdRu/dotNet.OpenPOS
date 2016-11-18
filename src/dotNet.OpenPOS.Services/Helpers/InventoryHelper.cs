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
            var inventory = new Inventory();

            inventory.Id = families.FirstOrDefault(f => f.Id == FamilyParentId).Id;
            inventory.FamilyName = families.FirstOrDefault(f => f.Id == FamilyParentId).Name;
            inventory.Products = products.Where(f => f.FamilyId == FamilyParentId);

            build(inventory, families.Where(f => f.ParentId == FamilyParentId), products); 

            return inventory;
        }

        private static void build(Inventory root, IEnumerable<ProductFamily> families, IEnumerable<Product> products)
        {
            if (families != null && families.Count() > 1)
            {
                var subFamilies = families.Where(f => f.ParentId == root.Id);
                foreach (var family in subFamilies)
                {
                    var inventory = new Inventory();

                    inventory.Id = family.Id;
                    inventory.FamilyName = family.Name;
                    inventory.Products = products.Where(f => f.FamilyId == family.Id);

                    build(inventory, families.Where(f => f.ParentId == inventory.Id), products);

                    root.ProductFamilies.Add(inventory);
                }               
            }          
        }        
    }
}
