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
        void Post(NewAlert newAlert);
        void PostBulk (List<NewAlert> newAlert);
        void Put(int id, NewAlert newAlert);
        void Delete(int id);
    }
}
