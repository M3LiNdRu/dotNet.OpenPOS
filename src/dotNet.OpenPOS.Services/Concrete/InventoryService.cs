﻿using dotNet.OpenPOS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Repositories.Interfaces;
using dotNet.OpenPOS.Services.Helpers;

namespace dotNet.OpenPOS.Services.Concrete
{
    public class InventoryService : IInventoryService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductFamilyRepository _productFamilyRepository;

        public InventoryService(IProductRepository productRepository,
            IProductFamilyRepository productFamilyRepository)
        {
            _productRepository = productRepository;
            _productFamilyRepository = productFamilyRepository;
        }

        public async Task<Inventory> GetInventoryAsync()
        {
            var result = new Inventory();
            var products = await _productRepository.GetAllAsync();
            var families = await _productFamilyRepository.GetAllAsync();

            result = InventoryHelper.BuildInventory(families, products);
            return result;
        }

        public async Task<IEnumerable<Product>> GetTopProductsAsync(int take)
        {
            var products = await _productRepository.GetAllAsync();

            return products.OrderBy(p => p.Sales).Take(take);
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _productRepository.FindByIdAsync(id);
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            return await _productRepository.InsertAsync(product);
        }

        public async Task<bool> EditProductAsync(Product product)
        {
            return await _productRepository.UpdateAsync(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }
    }
}
