using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using House.DAL.DataTransferObjects;
using House.DAL.Interfaces;
using House.HLL.Common;
using House.HLL.UniEvent.Interfaces;
using House.HLL.UniEvent.UniJson;

namespace House.HLL.UniEvent
{
    public class UniEventProvider : IUniEventProvider
    {
        private readonly IUniEventRepo _uniEventRepo;
        private readonly IUniEventServiceAgent _uniEventServiceAgent;

        public UniEventProvider(IUniEventRepo uniEventRepo, IUniEventServiceAgent uniEventServiceAgent)
        {
            _uniEventRepo = uniEventRepo;
            _uniEventServiceAgent = uniEventServiceAgent;
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

        public async Task<IEnumerable<Models.UniEvent>> Get(IEnumerable<int> id)
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

        public void RetrieveTimetableRows(KeyValue cookie)
        {
            var response = _uniEventServiceAgent.GetTimetableEvents(cookie);
            var newEvents = UniJsonSerializer.Serialize(response).ToList();
            _uniEventRepo.PostBulk(newEvents);
        }

        public void RunDedupe()
        {
            var allRows = Get().Result.ToList();
            var distinctData = allRows.Distinct().ToList();
            allRows.Where(x =>
                    !distinctData.Select(uniEvent => uniEvent.Id).Contains(x.Id)).ToList()
                    .ForEach(x => Delete(x.Id));
        }
    }
}