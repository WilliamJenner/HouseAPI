using System.Threading.Tasks;
using House.HLL.Dashboard.Bindicator.Interfaces;
using House.HLL.Dashboard.Bindicator.Models;
using Microsoft.Extensions.Options;

namespace House.HLL.Dashboard.Bindicator
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
