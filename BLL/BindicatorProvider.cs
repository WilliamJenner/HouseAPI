using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using UserService.BLL.Bindicator.Interfaces;
using UserService.BLL.Bindicator.Models;

namespace UserService.BLL
{
    public class BindicatorProvider : IBindicatorProvider
    {
        private readonly IBinLookupServiceAgent _bindicatorServiceAgent;
        private readonly string uprn;

        public BindicatorProvider(IBinLookupServiceAgent binlookupServiceAgent, IOptions<Lookup> options)
        {
            _bindicatorServiceAgent = binlookupServiceAgent;
            uprn = options.Value.Uprn;
        }

        public Task<BinLookup> Get()
        {
            return _bindicatorServiceAgent.Lookup(uprn);
        }
    }
}
