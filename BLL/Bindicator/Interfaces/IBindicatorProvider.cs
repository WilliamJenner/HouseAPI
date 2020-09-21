using System;
using System.Threading.Tasks;
using UserService.BLL.Bindicator.Models;

namespace UserService.BLL.Bindicator.Interfaces
{
    public interface IBindicatorProvider
    {
        Task<BinLookup> Get();
    }
}
