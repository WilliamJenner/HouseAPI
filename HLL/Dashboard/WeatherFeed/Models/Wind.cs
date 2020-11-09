using Newtonsoft.Json;

namespace House.HLL.Dashboard.WeatherFeed.Models
{
    public class Wind
    {
        [JsonProperty("speed")] public decimal Speed { get; set; }
        [JsonProperty("deg")] public decimal Degrees { get; set; }

    }
}
