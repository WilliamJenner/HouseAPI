using Newtonsoft.Json;

namespace House.HLL.Dashboard.WeatherFeed.Models
{
    public class Main
    {
        [JsonProperty("temp")] public long Temperature { get; set; }

        [JsonProperty("feels_like")] public decimal FeelsLike { get; set; }

        [JsonProperty("temp_min")] public decimal MinimumTemperature { get; set; }

        [JsonProperty("temp_max")] public decimal MaximumTemperature { get; set; }

        [JsonProperty("pressure")] public decimal Pressure { get; set; }

        [JsonProperty("humidity")] public decimal Humidity { get; set; }
    }
}