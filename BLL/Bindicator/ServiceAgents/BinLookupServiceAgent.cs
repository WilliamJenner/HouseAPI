using House.HLL.Models;
using House.HLL.ServiceAgents.Interfaces;
using RestSharp;
using House.HLL;
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

        public Task<BinLookupDto> Lookup(string uprn)
        {
            var request = new RestRequest(Method.GET)
                .AddParameter(nameof(uprn), uprn);
            return Retry.Do(() => GetBinData(request), TimeSpan.FromSeconds(1));
        }

        private async Task<BinLookupDto> GetBinData(IRestRequest request)
        {
            var result = await _lookupClient.GetAsync<BinLookupDto>(request);
            if (result == null)
                throw new NullReferenceException();
            return result;
        }
    }
}
