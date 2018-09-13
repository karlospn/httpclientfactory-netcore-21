using System;
using Microsoft.AspNetCore.Mvc;
using MultiServiceApp.WebApp1.Models;

namespace MultiServiceApp.WebApp1.Controllers
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
