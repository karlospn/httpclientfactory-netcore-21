using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace StandAloneApp.Infra.Proxies
{
    public class WebApp2Proxy : IWebApp2Proxy
    {
        private readonly HttpClient _client;

        public WebApp2Proxy(HttpClient client)
        {
            _client = client;
        }

        public async Task<WebApp2Dto> GetAsync(string uri)
        {
            var result = await _client.GetAsync(uri);
            if (result.IsSuccessStatusCode)
            {
                var stringify = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WebApp2Dto>(stringify);
            }

            //Return some kind of controlled error
            //I return an empty object for simplicity
            return new WebApp2Dto();
        }
    }
}
