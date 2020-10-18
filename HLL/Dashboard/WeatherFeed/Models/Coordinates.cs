using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace House.HLL.Dashboard.WeatherFeed.Models
{
    public class Coordinates
    {
        [JsonProperty("lon")]
        public decimal Longitude { get; set; }

        [JsonProperty("lat")]
        public decimal Latitude { get; set; }
    }
}
