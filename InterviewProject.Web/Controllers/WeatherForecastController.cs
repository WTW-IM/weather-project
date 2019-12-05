using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await weatherProvider.Get();
        }
    }
}
