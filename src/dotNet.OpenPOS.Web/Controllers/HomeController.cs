using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
            //TODO: Check if its first connection
            var itsFirstConnection = true;
            if (itsFirstConnection)
                return RedirectToAction("Initialize");

            var model = new HomeViewModel();

            model.Products = await _inventoryService.GetInventoryAsync();
            model.LastDailyOrders = await _orderService.GetDailyOrdersAsync();
            model.TopProducts = await _inventoryService.GetTopProductsAsync(5);

            return View(model);
        }

        public async Task<IActionResult> Initialize()
        {
            var model = new InitializeViewModel();
            return View(model);
        }

        public async Task<IActionResult> About()
        {
            var version = Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application.ApplicationVersion;
            var description = "Your application description page.";
            var license = "This software is under MIT License.";
            var credits = "Copyright (c) 2016 Roger Calaf";

            return Json(new { Description = description, License = license, Credits = credits, Version = version });
        }

        public async Task<IActionResult> Error()
        {
            return View();
        }
    }
}
