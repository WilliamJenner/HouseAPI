using System;
using System.Net;
using System.Net.Http;
using House.HLL.Dashboard.WeatherFeed.Interfaces;
using House.HLL.Dashboard.WeatherFeed.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using Serilog;

namespace House.HLL.Dashboard.WeatherFeed.ServiceAgents
{
    public class WeatherServiceAgent : IWeatherServiceAgent
    {
        private readonly string _apiKey;
        private IRestClient _weatherClient;

        public WeatherServiceAgent(IOptions<OpenWeatherApi> openWeatherApi, IOptions<ConnectionStrings> connectionStrings)
        {
            _apiKey = openWeatherApi.Value.Key;
            _weatherClient = new RestClient(connectionStrings.Value.OpenWeather);
        }

        public OpenWeatherCurrent Get()
        {
            var request = new RestRequest(Method.GET)
                .AddParameter("q", "Bournemouth")
                .AddParameter("units", "metric") // important, default is Kelvin
                .AddParameter("appid", _apiKey);
            return Retry.Retry.Do(() => GetWeatherData(request), TimeSpan.FromSeconds(1));

        }

        private OpenWeatherCurrent GetWeatherData(IRestRequest request)
        {
            var result = _weatherClient.Execute(request);

            if (result == null)
                throw new NullReferenceException();

            if (result.StatusCode != HttpStatusCode.OK)
            {
                var msg = $"Unexpected error {(int)result.StatusCode} status code from result";
                Log.Error(msg);
                throw new HttpRequestException(msg);
            }

            // Deserialize json and return
            return JsonConvert.DeserializeObject<OpenWeatherCurrent>(result.Content);
        }
    }
}
