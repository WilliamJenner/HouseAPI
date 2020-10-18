namespace House.DAL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using House.DAL.DataTransferObjects;

    public interface IUniEventRepo
    {
        Task<IEnumerable<UniEventDto>> Get();
        Task<IEnumerable<UniEventDto>> Get(int id);
        Task<IEnumerable<UniEventDto>> Get(IEnumerable<int> ids);
        void Post(NewUniEvent newEvent);
        void PostBulk(List<NewUniEvent> newEvent);
        void Put(int id, NewUniEvent newEvent);
        void Delete(int id);
    }
}
