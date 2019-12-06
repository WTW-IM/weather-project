using System.Collections.Generic;

namespace InterviewProject.Weather.Models
{

    public class MetaWeatherConsolidatedForecast
    {
        public string applicable_date { get; set; }
        public double the_temp { get; set; }
        public string weather_state_name { get; set; }
    }

    public class MetaWeatherForecast
    {
        public List<MetaWeatherConsolidatedForecast> consolidated_weather { get; set; }
    }
}