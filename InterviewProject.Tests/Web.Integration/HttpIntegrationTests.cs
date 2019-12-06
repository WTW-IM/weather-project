using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using InterviewProject.Domain.Exceptions;
using InterviewProject.Domain.Interfaces;

namespace InterviewProject.Web.Tests.Web.Integration
{
    public class TestResponse
    {
        public string Title { get; set; }
    }

    public class HttpIntegrationTests
    {
        [Fact]
        public async Task CanGetData()
        {
            //Arrange
            IHttp http = new Http(underlyingClient: new HttpClient());

            //Act
            //Assert
            (await http.Get<TestResponse[]>(url: "https://www.metaweather.com/api/location/search/?query=london"))
                .Should().BeEquivalentTo(new TestResponse[]{
                    new TestResponse{ Title = "London" }
                });
        }

        [Fact]
        public async Task ThrowsProperException()
        {
            //Arrange
            IHttp http = new Http(underlyingClient: new HttpClient());

            //Act
            //Assert
            await ((Func<Task>)(async () => await http.Get<TestResponse[]>(
                url: "https://www.metaweather.com/api/DNE-resource/search/?query=london")))
                .Should()
                .ThrowAsync<NetworkException>()
                .WithMessage("Not Found");
        }
    }
}
