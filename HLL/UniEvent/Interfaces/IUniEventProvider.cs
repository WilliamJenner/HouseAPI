using System.Collections.Generic;
using System.Threading.Tasks;
using House.DAL.DataTransferObjects;
using House.HLL.Common;

namespace House.HLL.UniEvent.Interfaces
{
    public interface IUniEventProvider
    {
        Task<IEnumerable<Models.UniEvent>> Get();
        Task<IEnumerable<Models.UniEvent>> Get(int id);
        Task<IEnumerable<Models.UniEvent>> Get(IEnumerable<int> id);
        void Post(NewUniEvent newEvent);
        void Put(int id, NewUniEvent newEvent);
        void Delete(int id);
        void RetrieveTimetableRows(KeyValue cookie);
        void RunDedupe();
    }
}