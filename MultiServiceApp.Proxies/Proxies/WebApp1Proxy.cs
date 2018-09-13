using System.Net.Http;
using System.Threading.Tasks;
using MultiServiceApp.Proxies.Base;
using MultiServiceApp.Proxies.Models.Base;
using MultiServiceApp.Proxies.Models.Dtos;

namespace MultiServiceApp.Proxies.Proxies
{
    public class WebApp1Proxy : IWebApp1Proxy
    {
        private readonly HttpClient _client;

        public WebApp1Proxy(HttpClient client)
        {
            _client = client;
        }

        public async Task<NotificationResult<WebApp1Dto>> GetAsync(string uri)
        {
            return await _client.GetAsync<WebApp1Dto>(uri);
        }

    }
}
