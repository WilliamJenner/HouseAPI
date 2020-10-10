using System.Collections.Generic;
using House.DAL.DataTransferObjects;

namespace House.DAL.Interfaces
{
    using System.Threading.Tasks;

    public interface IUniEventRepo
    {
        Task<IEnumerable<UniEventDto>> Get();
        Task<IEnumerable<UniEventDto>> Get(int id);
        Task<IEnumerable<UniEventDto>> Get(IEnumerable<int> ids);
        void Post(NewUniEvent newEvent);
        void PostBulk (List<NewUniEvent> newEvent);
        void Put(int id, NewUniEvent newEvent);
        void Delete(int id);
    }
}
