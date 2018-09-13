using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiServiceApp.WebApp3.Logic;

namespace MultiServiceApp.WebApp3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IApp3BusinessLogic _businessLogic;

        public ValuesController(IApp3BusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var result = await _businessLogic.DoWork();

            return result.IsToday.ToString();

        }
    }
}
