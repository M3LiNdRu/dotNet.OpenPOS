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
    public class ProductsController : Controller
    {
        private readonly IProductFamilyRepository _familiesRepo;
        private readonly IProductRepository _productsRepo;

        public ProductsController(IProductFamilyRepository familiesRepo, IProductRepository productsRepo)
        {
            _familiesRepo = familiesRepo;
            _productsRepo = productsRepo;
        }

        // GET: api/values
        [HttpGet]
        public async Task<BaseResponse> Get()
        {
            var families = await _familiesRepo.GetAllAsync();
            var products = await _productsRepo.GetAllAsync();

            var model = new Dictionary<string, IEnumerable<Product>>();

            foreach (var family in families)
            {
                model.Add(family.Name, products.Where(p => p.FamilyId == family.Id));
            }

            return new BaseResponse(true, model, "GetAll");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<BaseResponse> Get(int id)
        {
           var product = await _productsRepo.FindByIdAsync(id);

            return new BaseResponse(true, product, "GetById");
        }

        // POST api/values
        [HttpPost]
        public async Task<BaseResponse> Post([FromBody]Product value)
        {

            var inserted = await _productsRepo.InsertAsync(value);

            return new BaseResponse(inserted, null, "Inserted");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<BaseResponse> Put(int id, [FromBody]Product value)
        {
            var updated = await _productsRepo.UpdateAsync(value);

            return new BaseResponse(updated, null, "Updated");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse> Delete(int id)
        {
            var deleted = await _productsRepo.DeleteAsync(id);

            return new BaseResponse(deleted, null, "Deleted");
        }
    }
}
