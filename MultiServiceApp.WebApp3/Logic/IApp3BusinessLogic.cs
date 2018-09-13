using System.Threading.Tasks;
using MultiServiceApp.WebApp3.Models;

namespace MultiServiceApp.WebApp3.Logic
{
    public interface IApp3BusinessLogic
    {
        Task<WebApp3Model> DoWork();
    }
}
