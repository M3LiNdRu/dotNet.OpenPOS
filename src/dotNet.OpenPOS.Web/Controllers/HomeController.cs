using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using dotNet.OpenPOS.Web.Models;
using dotNet.OpenPOS.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using dotNet.OpenPOS.Repositories.Interfaces;

namespace dotNet.OpenPOS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInventoryService _inventoryService;
        private readonly IOrderService _orderService;
        private readonly IOptions<AppSettings> _optionsAccessor;
        private readonly IConfigurationRoot _configuration;
        private readonly IPaymentService _paymentService;
        private readonly ISettingsService _settings;

        public HomeController(IInventoryService inventoryService,IOrderService orderService,
            IOptions<AppSettings> optionsAccessor, IConfigurationRoot configuration, 
            IPaymentService paymentService, ISettingsService settings)
        {
            _inventoryService = inventoryService;
            _orderService = orderService;
            _optionsAccessor = optionsAccessor;
            _configuration = configuration;
            _paymentService = paymentService;
            _settings = settings;
        }

        public async Task<IActionResult> Index()
        {
            //TODO: Check if its first connection
            var itsFirstConnection = false; // _configuration.GetConnectionString("DefaultConnection") == string.Empty;
            if (itsFirstConnection)
                return RedirectToAction("Initialize");

            var model = new HomeViewModel();

            model.Products = await _inventoryService.GetInventoryAsync();
            model.LastDailyOrders = await _orderService.GetDailyOrdersAsync();
            model.TopProducts = await _inventoryService.GetTopProductsAsync(5);
            model.PaymentTypes = await _paymentService.GetPaymentTypesAsync();

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

        public async Task<IActionResult> Recycle()
        {
            _settings.RefreshDatabaseContext();

            return Json(new { success = true, message = "Singleton objects has been disposed" });
        }
    }
}
