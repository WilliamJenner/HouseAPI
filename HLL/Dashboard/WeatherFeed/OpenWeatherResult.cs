using System;
using System.Collections.Generic;
using System.Globalization;
using House.HLL.Dashboard.WeatherFeed.Models;

namespace House.HLL.Dashboard.WeatherFeed
{
    public class OpenWeatherResult
    {
        public Coordinates Cordinates { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public string Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public DateTime Date { get; set; }
        public Sys Sys { get; set; }
        public decimal TimeZone { get; set; }
        public decimal Id { get; set; }
        public string Name { get; set; }
        public decimal Cod { get; set; }

        public OpenWeatherResult(OpenWeatherCurrent openWeather)
        {
            Cordinates = openWeather.Cordinates;
            Weather = openWeather.Weather;
            Base = openWeather.Base;
            Main = openWeather.Main;
            Visibility = openWeather.Visibility;
            Wind = openWeather.Wind;
            Clouds = openWeather.Clouds;
            Date = DateTime.Parse(openWeather.Dt.ToString(CultureInfo.InvariantCulture));
            Sys = new Sys(openWeather.Sys);
            TimeZone = openWeather.TimeZone;
            Id = openWeather.Id;
            Name = openWeather.Name;
            Cod = openWeather.Cod;
        }
    }
}
