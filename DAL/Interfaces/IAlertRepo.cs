namespace House.DAL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using House.DAL.DataTransferObjects;

    public interface IAlertRepo
    {
        Task<IEnumerable<AlertDto>> Get();
        Task<IEnumerable<AlertDto>> Get(int id);
        Task<IEnumerable<AlertDto>> Get(IEnumerable<int> ids);
        void Post(NewAlert newEvent);
        void PostBulk (List<NewAlert> newEvent);
        void Put(int id, NewAlert newEvent);
        void Delete(int id);
    }
}
