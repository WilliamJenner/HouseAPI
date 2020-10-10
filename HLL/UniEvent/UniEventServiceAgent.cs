using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using House.HLL.Common;
using House.HLL.Dashboard.WeatherFeed.Models;
using House.HLL.UniEvent.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using Serilog;

namespace House.HLL.UniEvent
{
    public class UniEventServiceAgent : IUniEventServiceAgent
    {
        private IRestClient _uniClient;

        public UniEventServiceAgent(IOptions<ConnectionStrings> connectionStrings)
        {
            _uniClient = new RestClient(connectionStrings.Value.UniTimetable);
        }

        public IRestResponse GetTimetableEvents(KeyValue cookie)
        {
            var request = new RestRequest(Method.POST)
                .AddCookie(cookie.Key, cookie.Value);
            return Retry.Retry.Do(() => GetTimetableData(request), TimeSpan.FromSeconds(1));
        }

        private IRestResponse GetTimetableData(IRestRequest request)
        {
            var result = _uniClient.Execute(request);

            if (result == null)
                throw new NullReferenceException();

            if (result.StatusCode != HttpStatusCode.OK)
            {
                var msg = $"Unexpected error {(int)result.StatusCode} status code from result";
                Log.Error(msg);
                throw new HttpRequestException(msg);
            }

            // Deserialize json and return
            return result;
        }
    }
}
