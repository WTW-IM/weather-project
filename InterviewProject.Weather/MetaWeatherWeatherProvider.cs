using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewProject.Domain.Interfaces;
using InterviewProject.Domain.Models;
using InterviewProject.Weather.Models;

namespace InterviewProject.Weather
{
    public class MetaWeatherWeatherProvider : IWeatherProvider
    {
        private IHttp http;

        public MetaWeatherWeatherProvider(IHttp http)
        {
            this.http = http;
        }

        public async Task<IEnumerable<WeatherForecast>> GetForecastFor(string location)
        {
            var metaWeatherLocation = (await http
                .Get<MetaWeatherLocation[]>(url: $"https://www.metaweather.com/api/location/search/?query={location}"))
                .First();
            
            return (await http.Get<MetaWeatherForecast>(url: $"https://www.metaweather.com/api/location/{metaWeatherLocation.woeid}/"))
                .consolidated_weather
                .Select(forecast => new WeatherForecast
                {
                    Date = DateTime.Parse(forecast.applicable_date),
                    Summary = forecast.weather_state_name,
                    TemperatureC = (int)forecast.the_temp
                })
                .ToList();
        }
    }
}