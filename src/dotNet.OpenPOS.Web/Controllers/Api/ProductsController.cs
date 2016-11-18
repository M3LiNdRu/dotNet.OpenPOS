using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotNet.OpenPOS.Web.Models;
using dotNet.OpenPOS.Repositories.Interfaces;
using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Services.Interfaces;

namespace dotNet.OpenPOS.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public ProductsController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        // GET: api/products
        [HttpGet]
        public async Task<BaseResponse> Get()
        {
            var inventory = await _inventoryService.GetInventoryAsync();

            return new BaseResponse(true, inventory, "GetAll");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<BaseResponse> Get(int id)
        {
           var product = await _inventoryService.GetProductAsync(id);

            return new BaseResponse(true, product, "GetById");
        }

        // POST api/values
        [HttpPost]
        public async Task<BaseResponse> Post([FromBody]Product value)
        {

            var inserted = await _inventoryService.CreateProductAsync(value);

            return new BaseResponse(inserted, null, "Inserted");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<BaseResponse> Put(int id, [FromBody]Product value)
        {
            var updated = await _inventoryService.EditProductAsync(value);

            return new BaseResponse(updated, null, "Updated");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse> Delete(int id)
        {
            var deleted = await _inventoryService.DeleteProductAsync(id);

            return new BaseResponse(deleted, null, "Deleted");
        }
    }
}
