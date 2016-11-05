using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using dotNet.OpenPOS.Web.Models;
using dotNet.OpenPOS.Services.Interfaces;

namespace dotNet.OpenPOS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInventoryService _inventoryService;
        private readonly IOrderService _orderService;

        public HomeController(IInventoryService inventoryService,IOrderService orderService)
        {
            _inventoryService = inventoryService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel();

            model.Products = await _inventoryService.GetInventoryAsync();
            model.LastDailyOrders = await _orderService.GetDailyOrders();
            model.TopProducts = await _inventoryService.GetTopProductsAsync(5);

            return View(model);
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
