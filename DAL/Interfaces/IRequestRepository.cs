namespace House.DAL.Interfaces
{
    using System.Threading.Tasks;
    using House.DAL.Repositories;

    public interface IRequestRepository
    {
        public Task<bool> SaveRequestItem(SaveItemRequest request);

        public Task<decimal> GetAmountRequired();

        public Task<bool> ExpireRequestItems();
    }
}