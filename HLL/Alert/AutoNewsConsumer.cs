using System.Linq;
using House.DAL.DataTransferObjects;
using House.HLL.Alert.Interfaces;
using House.HLL.Alert.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace House.HLL.Alert
{
    public class AutoNewsConsumer : IAutoNewsConsumer
    {
        private readonly IRestClient _newsClient;
        private readonly IAlertProvider _alertProvider;


        public AutoNewsConsumer(IOptions<NewsApi> options, IOptions<ConnectionStrings> connectionStrings, IAlertProvider alertProvider)
        {
            _newsClient = new RestClient($"{connectionStrings.Value.NewsApi}{options.Value.Key}");
            _alertProvider = alertProvider;
        }

        public void Consume(int articlesToTake = 10)
        {
            var news = GetNewsData();
            foreach(var item in news.Articles.Take(articlesToTake))
            {
                _alertProvider.Post(new NewAlert { Message = item.Title, CreatedBy = item.Source.Name });
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
