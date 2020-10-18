namespace House.DAL
{
    using System.Threading.Tasks;

    public interface IRequestRepository
    {
        public Task<bool> SaveRequestItem(SaveItemRequest request);

        public Task<decimal> GetAmountRequired();

        public Task<bool> ExpireRequestItems();
    }
}