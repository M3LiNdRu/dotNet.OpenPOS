using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotNet.OpenPOS.Web.Models;
using dotNet.OpenPOS.Repositories.Interfaces;
using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Services.Interfaces;

namespace dotNet.OpenPOS.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<BaseResponse> Get()
        {
            var model = await _paymentService.GetAllPaymentsAsync();
            return new BaseResponse(true, model, "GetAll");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<BaseResponse> Get(int id)
        {
            var model = await _paymentService.FindPaymentsByOrderIdAsync(id);
            return new BaseResponse(true, model, "GetById");
        }

        // POST api/values
        [HttpPost]
        public async Task<BaseResponse> Post([FromBody]Payment value)
        {
            var inserted = await _paymentService.InsertPaymentAsync(value);
            return new BaseResponse(inserted, null, "Inserted");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<BaseResponse> Put(int id, [FromBody]Payment value)
        {
            var updated = await _paymentService.UpdatePaymentAsync(value);
            return new BaseResponse(updated, null, "Updated");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse> Delete(int id)
        {
            var deleted = await _paymentService.DeletePaymentAsync(id);
            return new BaseResponse(deleted, null, "Deleted");
        }
    }
}
