using House.HLL.Models;
using House.HLL.ServiceAgents.Interfaces;
using RestSharp;
using System;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Hosue.HLL.ServiceAgents
{
    public class BinLookupServiceAgent : IBinLookupServiceAgent
    {
        private readonly IRestClient _lookupClient;

        public BinLookupServiceAgent(IOptions<AppSettings> appSettings)
        {
            _lookupClient = new RestClient(appSettings.Value.BCPCouncilUrl);
        }

        public Task<BinLookup> Lookup(string uprn)
        {
            var request = new RestRequest(Method.GET)
                .AddParameter(nameof(uprn), uprn);
            return Retry.Do(() => GetBinData(request), TimeSpan.FromSeconds(1));
        }

        private async Task<BinLookup> GetBinData(IRestRequest request)
        {
            var result = await _lookupClient.GetAsync<BinLookupDto>(request);
            if (result == null)
                throw new NullReferenceException();
            return new BinLookup(result);
        }
    }
}
