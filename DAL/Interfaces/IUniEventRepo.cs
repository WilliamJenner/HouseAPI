using System.Collections.Generic;
using House.DAL.DataTransferObjects;

namespace House.DAL.Interfaces
{
    using System.Threading.Tasks;

    public interface IUniEventRepo
    {
        Task<IEnumerable<UniEventDto>> Get();
        Task<IEnumerable<UniEventDto>> Get(int id);
        void Post(NewUniEvent newEvent);
        void Put(int id, NewUniEvent newEvent);
        void Delete(int id);
    }
}
