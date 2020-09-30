using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.DAL.DataTransferObjects;
using House.DAL.Interfaces;
using House.HLL.UniEvent.Interfaces;

namespace House.HLL.UniEvent
{
    public class UniEventProvider : IUniEventProvider
    {
        private readonly IUniEventRepo _uniEventRepo;

        public UniEventProvider(IUniEventRepo uniEventRepo)
        {
            _uniEventRepo = uniEventRepo;
        }

        // It's fine having this return all uni events due to small volume of data
        // If we get to 1000 events, maybe rethink
        public async Task<IEnumerable<Models.UniEvent>> Get()
        {
            var result = await _uniEventRepo.Get();
            return result.Select(x => new Models.UniEvent(x));
        }

        public async Task<IEnumerable<Models.UniEvent>> Get(int id)
        {
            var result = await _uniEventRepo.Get(id);
            return result.Select(x => new Models.UniEvent(x));
        }

        public void Post(NewUniEvent newEvent)
        {
            _uniEventRepo.Post(newEvent);
        }

        public void Put(int id, NewUniEvent newEvent)
        {
            _uniEventRepo.Put(id, newEvent);
        }

        public void Delete(int id)
        {
            _uniEventRepo.Delete(id);
        }
    }
}
