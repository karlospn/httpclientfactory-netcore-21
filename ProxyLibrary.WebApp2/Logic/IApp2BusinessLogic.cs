using System.Threading.Tasks;
using ProxyLibrary.WebApp2.Models;

namespace ProxyLibrary.WebApp2.Logic
{
    public interface IApp2BusinessLogic
    {
        Task<WebApp2Model> DoWork();
    }
}
