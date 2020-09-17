using System.Threading.Tasks;
using House.HLL.Models;

namespace House.HLL.ServiceAgents.Interfaces
{
    public interface IBinLookupServiceAgent
    {
        Task<BinLookupDto> Lookup(string uprn);
    }
}
