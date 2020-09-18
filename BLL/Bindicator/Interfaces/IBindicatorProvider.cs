using System;
using System.Threading.Tasks;
using House.HLL.Models;

namespace House.HLL.Interfaces
{
    public interface IBindicatorProvider
    {
        Task<BinLookup> Get();
    }
}
