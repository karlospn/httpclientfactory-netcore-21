using System.Threading.Tasks;
using MultiServiceApp.Proxies.Models.Base;
using MultiServiceApp.Proxies.Models.Dtos;

namespace MultiServiceApp.Proxies.Proxies
{
    public interface IWebApp2Proxy
    {
        Task<NotificationResult<WebApp2Dto>> GetAsync(string uri);
    }
}