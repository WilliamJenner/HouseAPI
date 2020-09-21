using System.Threading.Tasks;
using House.HLL.Dashboard.Bindicator.Models;

namespace House.HLL.Dashboard.WeatherFeed.Interfaces
{
    public interface IWeatherProvider
    {
        Task<BinLookup> Get();
    }
}
