using System.Threading.Tasks;
using House.HLL.Dashboard.Bindicator.Models;

namespace House.HLL.Dashboard.WeatherFeed.Interfaces
{
    public interface IWeatherServiceAgent
    {
        Task<BinLookup> Lookup(string uprn);
    }
}
