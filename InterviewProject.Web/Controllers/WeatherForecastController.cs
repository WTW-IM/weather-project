using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace InterviewProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        [HttpGet("{code}")]
        public async Task<WeatherForecast> GetWeatherForcast([FromRoute]string code)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                            "https://www.metaweather.com/api/location/" + code);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            WeatherForecast weatherForecast = null;
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                weatherForecast = await JsonSerializer.DeserializeAsync
                    <WeatherForecast>(responseStream);
            }
            else
            {
                //log error
            }

            return weatherForecast;
        }

        [HttpGet("location-search/{query}")]
        public async Task<List<Location>> SearchLocationByText([FromRoute] string query)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                            "https://www.metaweather.com/api/location/search/?query=" + query);
            
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            var locations = new List<Location>();
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                locations = await JsonSerializer.DeserializeAsync
                    <List<Location>>(responseStream);
            }
            else
            {
                //log error
            }
            
            return locations;
        }
    }
}
