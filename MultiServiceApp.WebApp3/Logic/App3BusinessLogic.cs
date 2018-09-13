using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MultiServiceApp.Proxies.Proxies;
using MultiServiceApp.WebApp3.Models;

namespace MultiServiceApp.WebApp3.Logic
{
    public class App3BusinessLogic : IApp3BusinessLogic
    {
        private readonly IWebApp2Proxy _proxy;
        private readonly IConfiguration _config;

        public App3BusinessLogic(
            IWebApp2Proxy proxy,
            IConfiguration config)
        {
            _proxy = proxy;
            _config = config;
        }

        public async Task<WebApp3Model> DoWork()
        {
            var app2Result = await _proxy.GetAsync(_config["WebApp2Uri"]);

            var model = new WebApp3Model
            {
                IsToday = app2Result.Data.Flag
            };

            return model;
            
        }

       
    }
}
