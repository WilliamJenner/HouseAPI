using System.Threading.Tasks;

namespace House.DAL
{
    public interface IRequestRepository
    {
        public Task<bool> SaveRequestItem(SaveItemRequest request);

        public Task<decimal> GetAmountRequired();

        public Task<bool> ExpireRequestItems();
    }
}