using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace House.HLL.Dashboard.WeatherFeed.Models
{
    public abstract class WaterFromSky
    {
        [JsonProperty("1h")] public decimal VolumeOneHour { get; set; }
        [JsonProperty("3h")] public decimal VolumeThreeHour { get; set; }
    }
}