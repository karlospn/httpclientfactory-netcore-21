using System.Threading.Tasks;
using MultiServiceApp.WebApp2.Models;

namespace MultiServiceApp.WebApp2.Logic
{
    public interface IApp2BusinessLogic
    {
        Task<WebApp2Model> DoWork();
    }
}
