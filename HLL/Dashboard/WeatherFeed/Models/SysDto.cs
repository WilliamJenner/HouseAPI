using Newtonsoft.Json;

namespace House.HLL.Dashboard.WeatherFeed.Models
{
    public class SysDto
    {
        [JsonProperty("type")] public decimal Type { get; set; }
        [JsonProperty("id")] public decimal Id { get; set; }
        [JsonProperty("country")] public string Country { get; set; }
        [JsonProperty("sunrise")] public int Sunrise { get; set; }
        [JsonProperty("sunset")] public int Sunset { get; set; }
    }
}