using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using House.DAL.DataTransferObjects;
using House.DAL.Interfaces;
using House.HLL.Alert.Interfaces;
using House.HLL.Alert.Models;

namespace House.HLL.Alert
{
    public class AlertProvider : IAlertProvider
    {
        private readonly IUniEventRepo _uniEventRepo;

        public AlertProvider(IUniEventRepo uniEventRepo)
        {
            _uniEventRepo = uniEventRepo;
        }

        // It's fine having this return all uni events due to small volume of data
        // If we get to 1000 events, maybe rethink
        public async Task<IEnumerable<Models.Alert>> Get()
        {
            var result = await _uniEventRepo.Get();
            return result.Select(x => new UniEvent.Models.UniEvent(x));
        }

        public async Task<IEnumerable<Models.Alert>> Get(int id)
        {
            var result = await _uniEventRepo.Get(id);
            return result.Select(x => new UniEvent.Models.UniEvent(x));
        }

        public async Task<IEnumerable<Models.Alert>> Get(IEnumerable<int> id)
        {
            var result = await _uniEventRepo.Get(id);
            return result.Select(x => new UniEvent.Models.UniEvent(x));
        }

        public void Post(NewAlert newEvent)
        {
            _uniEventRepo.Post(newEvent);
        }

        public void Put(int id, NewAlert newEvent)
        {
            _uniEventRepo.Put(id, newEvent);
        }

        public void Delete(int id)
        {
            _uniEventRepo.Delete(id);
        }
    }
}