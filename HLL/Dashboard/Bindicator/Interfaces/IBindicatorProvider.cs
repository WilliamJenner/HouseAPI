using System.Threading.Tasks;
using House.HLL.Dashboard.Bindicator.Models;

namespace House.HLL.Dashboard.Bindicator.Interfaces
{
    public interface IBindicatorProvider
    {
        Task<BinLookup> Get();
    }
}
