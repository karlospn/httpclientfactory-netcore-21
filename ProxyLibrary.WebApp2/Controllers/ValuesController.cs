using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProxyLibrary.WebApp2.Helpers;
using ProxyLibrary.WebApp2.Logic;
using ProxyLibrary.WebApp2.Models;

namespace ProxyLibrary.WebApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IApp2BusinessLogic _logic;
        private readonly IHttpClientFactory _factory;

        public ValuesController(IApp2BusinessLogic logic, 
            IHttpClientFactory factory)
        {
            _logic = logic;
            _factory = factory;
        }

        // GET api/values
        [HttpGet("work")]
        public async Task<ActionResult<WebApp2Model>> Get()
        {
            return await _logic.DoWork();
        }
    
        [HttpGet("instance")]
        public string GetHttpClientInstance()
        {
            var result = _factory.GetFieldValue("_activeHandlers");

            return JsonConvert.SerializeObject(result);
        }
    }
}