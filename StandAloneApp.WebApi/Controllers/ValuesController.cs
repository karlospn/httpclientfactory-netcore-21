using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StandAloneApp.Business;

namespace StandAloneApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IBusinessLogic _businessLogic { get; }

        public ValuesController(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> GetAsync()
        {
            var result = await _businessLogic.DoWork();
            return JsonConvert.SerializeObject(result);
        }
    }
}
