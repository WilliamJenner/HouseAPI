using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using House.DAL.DataTransferObjects;
using House.DAL.Interfaces;
using House.HLL.Alert.Interfaces;

namespace House.HLL.Alert
{
    public class AlertProvider : IAlertProvider
    {
        private readonly IAlertRepo _alertRepo;

        public AlertProvider(IAlertRepo alertRepo)
        {
            _alertRepo = alertRepo;
        }

        public async Task<IEnumerable<Models.Alert>> Get()
        {
            var result = await _alertRepo.Get();
            return result.Select(x => new Models.Alert(x));
        }

        public async Task<IEnumerable<Models.Alert>> GetLatestAlerts()
        {
            var result = await _alertRepo.Get();
            return result.Select(x => new Models.Alert(x));
        }
        public async Task<IEnumerable<Models.Alert>> Get(int id)
        {
            var result = await _alertRepo.Get(id);
            return result.Select(x => new Models.Alert(x));
        }

        public async Task<IEnumerable<Models.Alert>> Get(IEnumerable<int> id)
        {
            var result = await _alertRepo.Get(id);
            return result.Select(x => new Models.Alert(x));
        }

        public void Post(NewAlert newAlert)
        {
            _alertRepo.Post(newAlert);
        }

        public void Put(int id, NewAlert newAlert)
        {
            _alertRepo.Put(id, newAlert);
        }

        public void Delete(int id)
        {
            _alertRepo.Delete(id);
        }
    }
}