using InterviewProject.Controllers;
using InterviewProject.Web.Test.Common;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InterviewProject.Web.Test
{
    public class WeatherForecastControllerTests : BaseControllerTest
    {
        [Fact]
        public async Task GetWeatherForcast_ReturnsDataSuccessfully()
        {
            // Arrange
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var url = "http://good.uri";
            var testData = GetEmbeddedJson("GetWeatherForecastTestData.json");
            var fakeHttpMessageHandler = new FakeHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(testData, Encoding.UTF8, "application/json")
            });
            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler);

            httpClientFactoryMock
                .Setup(h => h.CreateClient(It.IsAny<string>()))
                .Returns(fakeHttpClient);

            var loggerMock = new Mock<ILogger<WeatherForecastController>>();

            var controller = new WeatherForecastController(
                loggerMock.Object, 
                httpClientFactoryMock.Object);

            // Act
            var result = await controller.GetWeatherForcast("test");

            // Assert
            result.ShouldNotBe(null);
            result.Title.ShouldBe("London");
            result.ConsolidatedWeather.Count.ShouldBe(6);
            result.ConsolidatedWeather[0].WeatherStateName.ShouldBe("Showers");
            result.ConsolidatedWeather[0].ApplicableDate.ShouldBe("2020-02-16");
            result.ConsolidatedWeather[0].TheTemp.ShouldBe(9.850000000000001);
        }

        [Fact]
        public async Task SearchLocationByText_ReturnsDataSuccessfully()
        {
            // Arrange
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var url = "http://good.uri";
            var testData = GetEmbeddedJson("LocationSearchTestData.json");
            var fakeHttpMessageHandler = new FakeHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(testData, Encoding.UTF8, "application/json")
            });
            var fakeHttpClient = new HttpClient(fakeHttpMessageHandler);

            httpClientFactoryMock
                .Setup(h => h.CreateClient(It.IsAny<string>()))
                .Returns(fakeHttpClient);

            var loggerMock = new Mock<ILogger<WeatherForecastController>>();

            var controller = new WeatherForecastController(
                loggerMock.Object,
                httpClientFactoryMock.Object);

            // Act
            var result = await controller.SearchLocationByText("test");

            // Assert
            result.ShouldNotBe(null);
            result.Count.ShouldBe(11);
            result[0].Title.ShouldBe("San Francisco");
            result[0].LocationType.ShouldBe("City");
            result[0].Woeid.ShouldBe(2487956);
            result[0].LatLong.ShouldBe("37.777119, -122.41964");
        }
    }
}
