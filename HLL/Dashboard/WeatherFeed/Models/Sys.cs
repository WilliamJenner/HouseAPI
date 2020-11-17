using System;

namespace House.HLL.Dashboard.WeatherFeed.Models
{
    public class Sys
    {
        public decimal Type { get; set; }
        public decimal Id { get; set; }
        public string Country { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }

        public Sys(SysDto dto)
        {
            Type = dto.Type;
            Id = dto.Id;
            Country = dto.Country;
            Sunrise = DateTime.Parse(dto.Sunrise.ToString());
            Sunset = DateTime.Parse(dto.Sunset.ToString());
        }
    }
}