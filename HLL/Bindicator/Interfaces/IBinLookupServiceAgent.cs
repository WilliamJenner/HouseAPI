using System.Threading.Tasks;
using UserService.BLL.Bindicator.Models;

namespace UserService.BLL.Bindicator.Interfaces
{
    public interface IBinLookupServiceAgent
    {
        Task<BinLookup> Lookup(string uprn);
    }
}
