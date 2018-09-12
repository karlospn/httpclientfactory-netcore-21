using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ProxyLibrary.Proxies.Proxies;
using ProxyLibrary.WebApp2.Models;

namespace ProxyLibrary.WebApp2.Logic
{
    public class App2BusinessLogic : IApp2BusinessLogic
    {
        private readonly IWebApp1Proxy _proxy;
        private readonly IConfiguration _config;

        public App2BusinessLogic(
            IWebApp1Proxy proxy,
            IConfiguration config)
        {
            _proxy = proxy;
            _config = config;
        }

        public async Task<WebApp2Model> DoWork()
        {
            var app1Result = await _proxy.GetAsync(_config["WebApp1Uri"]);

            if (app1Result.Errors.Any())
            {
                //We throw an exception to go fast but we should control the error 
                throw new Exception("Proxy call error");
            }

            var model = new WebApp2Model
            {
                DataList = new[] {app1Result.Data.Data}, 
                Flag = app1Result.Data.Date == DateTime.Today
            };
            return model;
            
        }

       
    }
}
