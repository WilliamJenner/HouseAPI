using System;
using System.Linq;
using System.Threading.Tasks;
using House.DAL.Interfaces;
using House.HLL.Alert.Interfaces;
using House.HLL.Alert.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace House.HLL.Alert
{
    public class AutoNewsConsumer : IAutoNewsConsumer
    {
        private readonly string _apiKey;
        private readonly IRestClient _newsClient;
        private readonly IAlertProvider alertProvider;


        public AutoNewsConsumer(IOptions<NewsApi> options, IOptions<ConnectionStrings> connectionStrings, IAlertProvider alertProvider)
        {
            _apiKey = options.Value.Key;
            _newsClient = new RestClient($"{connectionStrings.Value.OpenWeather}{_apiKey}");
            this.alertProvider = alertProvider;
        }

        public void Consume()
        {
            var news = GetNewsData();
            foreach(var item in news.Articles.Take(10))
            {
                alertProvider.Post(new DAL.DataTransferObjects.NewAlert { Message = item.Title, CreatedBy = item.Source.Name });
            }
        }

        private Root GetNewsData()
        {
            var request = new RestRequest(Method.GET);
            var result = _newsClient.Execute(request);
            return JsonConvert.DeserializeObject<Root>(result.Content);
        }
    }
}
