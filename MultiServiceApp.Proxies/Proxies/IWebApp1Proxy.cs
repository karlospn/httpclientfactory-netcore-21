using System.Threading.Tasks;
using MultiServiceApp.Proxies.Models.Base;
using MultiServiceApp.Proxies.Models.Dtos;

namespace MultiServiceApp.Proxies.Proxies
{
    public interface IWebApp1Proxy
    {
        Task<NotificationResult<WebApp1Dto>> GetAsync(string uri);
    }
}