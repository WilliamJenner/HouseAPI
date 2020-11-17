using System.Collections.Generic;
using System.Threading.Tasks;
using House.DAL.DataTransferObjects;

namespace House.HLL.Alert.Interfaces
{
    public interface IAlertProvider
    {
        Task<IEnumerable<Models.Alert>> Get();
        Task<IEnumerable<Models.Alert>> GetLatestAlerts();

        Task<IEnumerable<Models.Alert>> Get(int id);
        Task<IEnumerable<Models.Alert>> Get(IEnumerable<int> id);
        void Post(NewAlert newAlert);
        void Put(int id, NewAlert newAlert);
        void Delete(int id);
    }
}