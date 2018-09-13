using System.Net.Http;
using System.Threading.Tasks;
using MultiServiceApp.Proxies.Base;
using MultiServiceApp.Proxies.Models.Base;
using MultiServiceApp.Proxies.Models.Dtos;

namespace MultiServiceApp.Proxies.Proxies
{
    public class WebApp2Proxy : IWebApp2Proxy
    {
        private readonly HttpClient _client;

        public WebApp2Proxy(HttpClient client)
        {
            _client = client;
        }

        public async Task<NotificationResult<WebApp2Dto>> GetAsync(string uri)
        {
            return await _client.GetAsync<WebApp2Dto>(uri);
        }
    }
}
