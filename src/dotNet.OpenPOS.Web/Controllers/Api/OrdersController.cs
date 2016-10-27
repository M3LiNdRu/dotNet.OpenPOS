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
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepo;

        public OrdersController(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }
        // GET: api/values
        [HttpGet]
        public async Task<BaseResponse> Get()
        {
            var model = await _orderRepo.GetAllAsync();
            return new BaseResponse(true, model, "GetAll");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<BaseResponse> Get(int id)
        {
            var model = await _orderRepo.FindByIdAsync(id);
            return new BaseResponse(true, model, "GetById");
        }

        // POST api/values
        [HttpPost]
        public async Task<BaseResponse> Post([FromBody]Order value)
        {
            var inserted = await _orderRepo.InsertAsync(value);
            return new BaseResponse(inserted, null, "Inserted");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<BaseResponse> Put(int id, [FromBody]Order value)
        {
            var updated = await _orderRepo.UpdateAsync(value);
            return new BaseResponse(updated, null, "Updated");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse> Delete(int id)
        {
            var deleted = await _orderRepo.DeleteAsync(id);
            return new BaseResponse(deleted, null, "Deleted");
        }
    }
}
