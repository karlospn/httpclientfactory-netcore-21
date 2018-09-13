using System.Threading.Tasks;

namespace StandAloneApp.Infra.Proxies
{
    public interface IWebApp2Proxy
    {
        Task<WebApp2Dto> GetAsync(string uri);
    }
}
