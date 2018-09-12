using System;
using Microsoft.AspNetCore.Mvc;
using ProxyLibrary.WebApp1.Models;

namespace ProxyLibrary.WebApp1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<WebApp1Model> Get()
        {
            return new WebApp1Model
            {
                Data = "test",
                Date = DateTime.UtcNow,
                Value = 5
            };
        }

      
    }
}
