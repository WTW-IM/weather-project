using System.Collections.Generic;
using System.Threading.Tasks;
using InterviewProject.Domain.Models;

namespace InterviewProject.Domain.Interfaces
{
    public interface IWeatherProvider
    {
        Task<IEnumerable<WeatherForecast>> GetForecastFor(string location);
    }
}