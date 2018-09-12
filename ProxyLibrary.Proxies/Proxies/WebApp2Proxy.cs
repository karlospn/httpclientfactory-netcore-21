using System.Net.Http;
using System.Threading.Tasks;
using ProxyLibrary.Proxies.Base;
using ProxyLibrary.Proxies.Models.Base;
using ProxyLibrary.Proxies.Models.Dtos;

namespace ProxyLibrary.Proxies.Proxies
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
