namespace House.API.Controllers
{
    using System;
    using HLL.Dashboard.WeatherFeed.Interfaces;
    using HLL.Dashboard.WeatherFeed.Models;
    using Microsoft.AspNetCore.Mvc;
    using Serilog;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherProvider _weatherProvider;

        public WeatherForecastController(IWeatherProvider weatherProvider)
        {
            _weatherProvider = weatherProvider;
        }

        [HttpGet]
        public OpenWeatherCurrent Get()
        {
            try
            {
                return _weatherProvider.Get();
            }
            catch (Exception e)
            {
                Log.Error("Error Getting Weather Information", e);
                throw;
            }
        }
    }
}
