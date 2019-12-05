using System.Collections.Generic;
using InterviewProject.Domain.Interfaces;
using InterviewProject.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InterviewProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> logger;
        private readonly IWeatherProvider weatherProvider;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IWeatherProvider weatherProvider)
        {
            this.logger = logger;
            this.weatherProvider = weatherProvider;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return weatherProvider.Get();
        }
    }
}
