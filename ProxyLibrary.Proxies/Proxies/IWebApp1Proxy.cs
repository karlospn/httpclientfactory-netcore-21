using System.Threading.Tasks;
using ProxyLibrary.Proxies.Models.Base;
using ProxyLibrary.Proxies.Models.Dtos;

namespace ProxyLibrary.Proxies.Proxies
{
    public interface IWebApp1Proxy
    {
        Task<NotificationResult<WebApp1Dto>> GetAsync(string uri);
    }
}