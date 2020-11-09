namespace House.DAL.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using House.DAL.DataTransferObjects;
    using House.DAL.Repositories;

    public interface IRequestRepository
    {
        public Task<bool> SaveRequestItem(SaveItemRequest request);

        public Task<decimal> GetAmountRequired();

        public Task<IEnumerable<RequestDto>> GetActiveRequests();

        public Task<bool> ExpireRequestItems();
    }
}