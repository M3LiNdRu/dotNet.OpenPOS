using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotNet.OpenPOS.Web.Models;
using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Services.Interfaces;


namespace dotNet.OpenPOS.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderRepo)
        {
            _orderService = orderRepo;
        }
        // GET: api/values
        [HttpGet]
        public async Task<BaseResponse> Get()
        {
            var model = await _orderService.GetAllOrdersAsync();
            return new BaseResponse(true, model, "GetAll");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<BaseResponse> Get(int id)
        {
            var model = await _orderService.GetOrderByIdAsync(id);
            return new BaseResponse(true, model, "GetById");
        }

        // POST api/orders
        [HttpPost]
        public async Task<BaseResponse> Post([FromBody]Order value)
        {
            var inserted = await _orderService.InsertOrderAsync(value);
            return new BaseResponse(inserted, null, "Inserted");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<BaseResponse> Put(int id, [FromBody]Order value)
        {
            var updated = await _orderService.UpdateOrderAsync(value);
            return new BaseResponse(updated, null, "Updated");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse> Delete(int id)
        {
            var deleted = await _orderService.DeleteOrderAsync(id);
            return new BaseResponse(deleted, null, "Deleted");
        }
    }
}
