using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotNet.OpenPOS.Web.Models;
using dotNet.OpenPOS.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace dotNet.OpenPOS.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class TicketsController : Controller
    {
        private readonly IOrderService _orderService;

        public TicketsController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/tickets
        [HttpGet]
        public async Task<BaseResponse> Get()
        {
            return new BaseResponse(false, null, "Not Implemented");
        }

        // GET api/tickets/5
        [HttpGet("{id}")]
        public async Task<BaseResponse> Get(int id)
        {
            var ticket = await _orderService.GetTicketByOrderIdAsync(id);

            return new BaseResponse(true, ticket, "Get");
        }

        // POST api/tickets
        [HttpPost]
        public async Task<BaseResponse> Post([FromBody]TicketInfo item)
        {
            var saved = await _orderService.SavePrintedTicketAsync(item.Ticket, item.OrderId);

            return new BaseResponse(saved, null, "Printed ticket saved.");
        }

        // PUT api/tickets/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/tickets/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
