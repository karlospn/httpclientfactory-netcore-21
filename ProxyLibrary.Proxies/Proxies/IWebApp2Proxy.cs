using System.Threading.Tasks;
using ProxyLibrary.Proxies.Models.Base;
using ProxyLibrary.Proxies.Models.Dtos;

namespace ProxyLibrary.Proxies.Proxies
{
    public interface IWebApp2Proxy
    {
        Task<NotificationResult<WebApp2Dto>> GetAsync(string uri);
    }
}