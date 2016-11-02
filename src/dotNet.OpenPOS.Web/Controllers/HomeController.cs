﻿using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace dotNet.OpenPOS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductFamilyRepository _productFamilyRepository;
        private readonly IOrderRepository _orderRepository;

        public HomeController(IProductRepository productRepository, 
            IProductFamilyRepository productFamilyRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _productFamilyRepository = productFamilyRepository;
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index()
        {
            var viewProducts = new Dictionary<string, IEnumerable<Product>>();

            var families = await _productFamilyRepository.GetAllAsync();
            var products = await _productRepository.GetAllAsync();
            var orders = await _orderRepository.GetAllAsync();

            foreach (var family in families)
            {
                viewProducts.Add(family.Name, products.Where(p => p.FamilyId == family.Id));
            }

            ViewData["Products"] = viewProducts;
            ViewData["Orders"] = orders;
            ViewData["TopProducts"] = products
                .OrderBy(p => p.Sales)
                .Take(5)
                .Select(p => new { Name = p.Name, Sales = p.Sales });

            return View();
        }

        public async Task<IActionResult> About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public async Task<IActionResult> Error()
        {
            return View();
        }
    }
}
