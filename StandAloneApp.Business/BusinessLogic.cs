using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using StandAloneApp.Business.Models;
using StandAloneApp.Infra.Proxies;

namespace StandAloneApp.Business
{
    public class BusinessLogic : IBusinessLogic
    {
        private readonly IWebApp2Proxy _proxy;
        private readonly IConfiguration _config;

        public BusinessLogic(
            IWebApp2Proxy proxy,
            IConfiguration config)
        {
            _proxy = proxy;
            _config = config;
        }

        public async Task<BusinessModel> DoWork()
        {
            var app1Result = await _proxy.GetAsync(_config["WebApp2Uri"]);

            var model = new BusinessModel
            {
                IsToday = app1Result.Flag
            };

            return model;
            
        }

       
    }
}
