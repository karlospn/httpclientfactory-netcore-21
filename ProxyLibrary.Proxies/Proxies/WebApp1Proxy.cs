using System.Net.Http;
using System.Threading.Tasks;
using ProxyLibrary.Proxies.Base;
using ProxyLibrary.Proxies.Models.Base;
using ProxyLibrary.Proxies.Models.Dtos;

namespace ProxyLibrary.Proxies.Proxies
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
