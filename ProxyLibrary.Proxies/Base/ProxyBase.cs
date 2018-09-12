using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProxyLibrary.Proxies.Models.Base;

namespace ProxyLibrary.Proxies.Base
{
    public static class ProxyBase
    {
        public static async Task<NotificationResult<TData>> GetAsync<TData>(this HttpClient client, string uri)
        {
            var obj = new NotificationResult<TData>();
            var result = await client.GetAsync(uri);

            if (result.IsSuccessStatusCode)
            {
                var stringify = await result.Content.ReadAsStringAsync();
                obj.Data = JsonConvert.DeserializeObject<TData>(stringify);
            }
            else
            {
                (obj.Errors as List<Error>)?.Add(new Error
                {
                    Message = result.ReasonPhrase
                });
            }

            return obj;
        }
    }
}
