using House.HLL.Dashboard.WeatherFeed.Models;

namespace House.HLL.Dashboard.WeatherFeed.Interfaces
{
    public interface IWeatherServiceAgent
    {
        OpenWeatherCurrent Get();
    }
}
