using System.Threading.Tasks;
using House.HLL.Models;

namespace House.HLL.ServiceAgents.Interfaces
{
    public interface IBinLookupServiceAgent
    {
        Task<BinLookup> Lookup(string uprn);
    }
}
