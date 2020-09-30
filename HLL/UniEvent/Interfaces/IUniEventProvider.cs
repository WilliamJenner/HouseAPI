using System.Collections.Generic;
using System.Threading.Tasks;
using House.DAL.DataTransferObjects;

namespace House.HLL.UniEvent.Interfaces
{
    public interface IUniEventProvider
    {
        Task<IEnumerable<Models.UniEvent>> Get();
        Task<IEnumerable<Models.UniEvent>> Get(int id);
        void Post(NewUniEvent newEvent);
        void Put(int id, NewUniEvent newEvent);
        void Delete(int id);
    }
}