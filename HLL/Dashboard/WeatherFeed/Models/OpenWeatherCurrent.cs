using System.Collections.Generic;
using Newtonsoft.Json;

namespace House.HLL.Dashboard.WeatherFeed.Models
{
    public class OpenWeatherCurrent
    {
        [JsonProperty("coord")] public Coordinates Cordinates { get; set; }
        [JsonProperty("weather")] public List<Weather> Weather { get; set; }
        [JsonProperty("base")] public string Base { get; set; }
        [JsonProperty("main")] public Main Main { get; set; }
        [JsonProperty("visibility")] public string Visibility { get; set; }
        [JsonProperty("wind")] public Wind Wind { get; set; }
        [JsonProperty("clouds")] public Clouds Clouds { get; set; }
        [JsonProperty("dt")] public decimal Dt { get; set; }
        [JsonProperty("sys")] public SysDto Sys { get; set; }
        [JsonProperty("timezone")] public decimal TimeZone { get; set; }
        [JsonProperty("id")] public decimal Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("cod")] public decimal Cod { get; set; }
    }
}