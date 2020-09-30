using System.Threading.Tasks;
using House.HLL.Dashboard.Bindicator.Models;
using House.HLL.Dashboard.WeatherFeed.Models;
using OpenWeatherMap.Standard.Models;

namespace House.HLL.Dashboard.WeatherFeed.Interfaces
{
    public interface IWeatherServiceAgent
    {
        OpenWeatherCurrent Get();
    }
}
