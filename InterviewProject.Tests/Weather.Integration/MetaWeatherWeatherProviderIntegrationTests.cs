using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using InterviewProject.Weather;
using Xunit;

namespace InterviewProject.Web.Tests.Weather.Integration
{
    public class MetaWeatherWeatherProviderIntegrationTests
    {
        [Fact]
        public async Task ShouldGetWeatherFromMetaWeather()
        {
            //Arrange
            var weatherProvider = new MetaWeatherWeatherProvider(new Http(new HttpClient()));

            //Act
            var forecasts = (await weatherProvider.GetForecastFor(location: "London")).ToList();

            //Assert
            forecasts.Count.Should().BeGreaterThan(0);
            forecasts.ForEach(forecast =>
            {
                forecast.Summary.Should().NotBeNullOrWhiteSpace();
            });
        }
    }
}