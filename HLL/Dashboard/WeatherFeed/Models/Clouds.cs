using Newtonsoft.Json;

namespace House.HLL.Dashboard.WeatherFeed.Models
{
    public class Clouds
    {
        [JsonProperty("all")] public decimal All { get; set; }
    }
}
