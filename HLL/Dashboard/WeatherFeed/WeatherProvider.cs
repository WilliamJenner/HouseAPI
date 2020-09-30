using System.Threading.Tasks;
using House.HLL.Dashboard.Bindicator.Models;
using House.HLL.Dashboard.WeatherFeed.Interfaces;
using House.HLL.Dashboard.WeatherFeed.Models;
using Microsoft.Extensions.Options;
using OpenWeatherMap.Standard.Models;

namespace House.HLL.Dashboard.WeatherFeed
{
    public class WeatherProvider : IWeatherProvider
    {
        private readonly IWeatherServiceAgent _weatherServiceAgent;

        public WeatherProvider(IWeatherServiceAgent weatherServiceAgent)
        {
            _weatherServiceAgent = weatherServiceAgent;
        }

        public OpenWeatherCurrent Get()
        {
            return _weatherServiceAgent.Get();
        }
    }
}