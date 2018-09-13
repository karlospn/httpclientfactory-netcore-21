using System.Threading.Tasks;
using StandAloneApp.Business.Models;

namespace StandAloneApp.Business
{
    public interface IBusinessLogic
    {
        Task<BusinessModel> DoWork();
    }
}
