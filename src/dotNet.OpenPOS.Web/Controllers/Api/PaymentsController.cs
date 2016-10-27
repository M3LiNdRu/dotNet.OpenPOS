using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotNet.OpenPOS.Web.Models;
using dotNet.OpenPOS.Repositories.Interfaces;
using dotNet.OpenPOS.Domain.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dotNet.OpenPOS.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentRepository _paymentRepo;

        public PaymentsController(IPaymentRepository paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        // GET: api/values
        [HttpGet]
        public async Task<BaseResponse> Get()
        {
            var model = await _paymentRepo.GetAllAsync();
            return new BaseResponse(true, model, "GetAll");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<BaseResponse> Get(int id)
        {
            var model = await _paymentRepo.FindByIdAsync(id);
            return new BaseResponse(true, model, "GetById");
        }

        // POST api/values
        [HttpPost]
        public async Task<BaseResponse> Post([FromBody]Payment value)
        {
            var inserted = await _paymentRepo.InsertAsync(value);
            return new BaseResponse(inserted, null, "Inserted");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<BaseResponse> Put(int id, [FromBody]Payment value)
        {
            var updated = await _paymentRepo.UpdateAsync(value);
            return new BaseResponse(updated, null, "Updated");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse> Delete(int id)
        {
            var deleted = await _paymentRepo.DeleteAsync(id);
            return new BaseResponse(deleted, null, "Deleted");
        }
    }
}
