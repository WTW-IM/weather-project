using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using InterviewProject.Controllers;
using InterviewProject.Domain.Interfaces;
using InterviewProject.Domain.Models;
using InterviewProject.Weather;
using InterviewProject.Weather.Models;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace InterviewProject.Web.Tests.Web.Acceptance.Controllers
{
    public class WeatherForecastControllerAcceptanceTests
    {
        [Fact]
        public async Task GetsTheWeatherForecast()
        {
            //Arrange
            var http = Substitute.For<IHttp>();
            http
                .Get<MetaWeatherLocation[]>("https://www.metaweather.com/api/location/search/?query=London")
                .Returns(new MetaWeatherLocation[] { new MetaWeatherLocation { woeid = "LOCATION-ID" } });
            http
                .Get<MetaWeatherForecast>("https://www.metaweather.com/api/location/LOCATION-ID/")
                .Returns(new MetaWeatherForecast
                {
                    consolidated_weather = new List<MetaWeatherConsolidatedForecast>
                    {
                        new MetaWeatherConsolidatedForecast
                        {
                            applicable_date = "01/01/2000",
                            the_temp = 25,
                            weather_state_name = "windy"
                        }
                    }
                });

            var controller = new WeatherForecastController(
                logger: Substitute.For<ILogger<WeatherForecastController>>(),
                weatherProvider: new MetaWeatherWeatherProvider(http));

            //Act
            //Assert
            (await controller.GetForecastFor(location: "London")).Should().BeEquivalentTo(new WeatherForecast[]
            {
                new WeatherForecast
                {
                    Date = DateTime.Parse("01/01/2000"),
                    Summary = "windy",
                    TemperatureC = 25
                }
            });
        }
    }
}