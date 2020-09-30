using System;
using System.Threading.Tasks;
using House.HLL.Dashboard.Bindicator.Interfaces;
using House.HLL.Dashboard.Bindicator.Models;
using House.HLL.Dashboard.WeatherFeed.Models;
using Microsoft.Extensions.Options;
using RestSharp;

namespace House.HLL.Dashboard.Bindicator.ServiceAgents
{
    public class BinLookupServiceAgent : IBinLookupServiceAgent
    {
        private readonly IRestClient _lookupClient;

        public BinLookupServiceAgent(IOptions<ConnectionStrings> connectionStrings)
        {
            _lookupClient = new RestClient(connectionStrings.Value.BCPCouncil);
        }

        public Task<BinLookup> Lookup(string uprn)
        {
            var request = new RestRequest(Method.GET)
                .AddParameter(nameof(uprn), uprn);
            return Retry.Retry.Do(() => GetBinData(request), TimeSpan.FromSeconds(1));
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
