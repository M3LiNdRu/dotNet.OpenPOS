using dotNet.OpenPOS.Domain.Models;
using dotNet.OpenPOS.Services.Interfaces;
using dotNet.OpenPOS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace dotNet.OpenPOS.Web.Controllers.Api
{
    [Route("api/[controller]")]
    public class InitialConfigurationController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IConfigurationRoot _configuration;

        public InitialConfigurationController(IAccountService accountService, IConfigurationRoot configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }


        [Route("api/[controller]/dbconfiguration")]
        [HttpPost]
        public async Task<BaseResponse> PostDatabaseConfiguration([FromBody] DatabaseConnectionConfig config)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new BaseResponse(true, null, "PostDatabaseConfiguration");
        }

        [Route("api/[controller]/accountconfiguration")]
        [HttpPost]
        public async Task<BaseResponse> PostAccountConfiguration([FromBody] Account account)
        {
            var response = await _accountService.InsertAsync(account);
            return new BaseResponse(response, null, "PostAccountConfiguration");
        }
    }
}
