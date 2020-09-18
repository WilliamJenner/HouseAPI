using System;
using System.Threading.Tasks;
using House.HLL.Interfaces;
using House.HLL.Models;
using House.HLL.ServiceAgents.Interfaces;
using Microsoft.Extensions.Options;
using House.HLL.ServiceAgents;

namespace House.HLL
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
