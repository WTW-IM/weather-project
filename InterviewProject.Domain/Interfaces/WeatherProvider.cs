using System.Collections.Generic;
using InterviewProject.Domain.Models;

namespace InterviewProject.Domain.Interfaces
{
    public interface IWeatherProvider
    {
        IEnumerable<WeatherForecast> Get();
    }
}