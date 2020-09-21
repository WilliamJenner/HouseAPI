using System.Threading.Tasks;
using House.HLL.Dashboard.Bindicator.Models;

namespace House.HLL.Dashboard.Bindicator.Interfaces
{
    public interface IBinLookupServiceAgent
    {
        Task<BinLookup> Lookup(string uprn);
    }
}
