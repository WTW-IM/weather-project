using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InterviewProject
{
    public class WeatherForecast
    {
        [JsonPropertyName("consolidated_weather")]
        public List<ConsolidatedWeather> ConsolidatedWeather { get; set; }
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
        [JsonPropertyName("sun_rise")]
        public DateTime SunRise { get; set; }
        [JsonPropertyName("sun_set")]
        public DateTime SunSet { get; set; }
        [JsonPropertyName("timezone_name")]
        public string TimezoneName { get; set; }
        [JsonPropertyName("parent")]
        public Location Parent { get; set; }
        [JsonPropertyName("sources")]
        public List<Source> Sources { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("location_type")]
        public string LocationType { get; set; }
        [JsonPropertyName("woeid")]
        public int Woeid { get; set; }
        [JsonPropertyName("latt_long")]
        public string LatLong { get; set; }
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }
    }

    public class ConsolidatedWeather
    {
        [JsonPropertyName("id")]
        public Int64 Id { get; set; }
        [JsonPropertyName("weather_state_name")]
        public string WeatherStateName { get; set; }
        [JsonPropertyName("weather_state_abbr")]
        public string WeatherStateAbbr { get; set; }
        [JsonPropertyName("wind_direction_compass")]
        public string WindDirectionCompass { get; set; }
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }
        [JsonPropertyName("applicable_date")]
        public string ApplicableDate { get; set; }
        public string DisplayDate => DateTime.Parse(ApplicableDate).ToLongDateString();
        [JsonPropertyName("min_temp")]
        public double MinTemp { get; set; }
        [JsonPropertyName("max_temp")]
        public double MaxTemp { get; set; }
        [JsonPropertyName("the_temp")]
        public double TheTemp { get; set; }
        [JsonPropertyName("wind_speed")]
        public double WindSpeed { get; set; }
        [JsonPropertyName("wind_direction")]
        public double WindDirection { get; set; }
        [JsonPropertyName("air_pressure")]
        public double AirPressure { get; set; }
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
        [JsonPropertyName("visibility")]
        public double Visibility { get; set; }
        [JsonPropertyName("predictability")]
        public int Predictability { get; set; }
    }

    public class Source
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("slug")]
        public string Slug { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("crawl_rate")]
        public int CrawlRate { get; set; }
    }
}


//{"consolidated_weather":[{"id":4949420871254016,"weather_state_name":"Showers","weather_state_abbr":"s","wind_direction_compass":"SW","created":"2020-02-16T21:16:02.844426Z","applicable_date":"2020-02-16","min_temp":5.984999999999999,"max_temp":10.155000000000001,"the_temp":9.850000000000001,"wind_speed":11.733740480932687,"wind_direction":229.65270805159884,"air_pressure":998.0,"humidity":72,"visibility":5.147128270897955,"predictability":73},{"id":5973704376844288,"weather_state_name":"Showers","weather_state_abbr":"s","wind_direction_compass":"WSW","created":"2020-02-16T21:16:02.852746Z","applicable_date":"2020-02-17","min_temp":5.3100000000000005,"max_temp":10.305,"the_temp":9.355,"wind_speed":12.39170421352634,"wind_direction":236.34673867434657,"air_pressure":1008.5,"humidity":59,"visibility":11.279751252684324,"predictability":73},{"id":5359345007067136,"weather_state_name":"Light Rain","weather_state_abbr":"lr","wind_direction_compass":"WSW","created":"2020-02-16T21:16:02.431457Z","applicable_date":"2020-02-18","min_temp":4.5600000000000005,"max_temp":9.54,"the_temp":9.25,"wind_speed":12.010263572891645,"wind_direction":244.50209787893985,"air_pressure":1019.5,"humidity":63,"visibility":12.844053229141812,"predictability":75},{"id":5294304035602432,"weather_state_name":"Light Rain","weather_state_abbr":"lr","wind_direction_compass":"WSW","created":"2020-02-16T21:16:02.454537Z","applicable_date":"2020-02-19","min_temp":3.3899999999999997,"max_temp":9.165,"the_temp":7.885,"wind_speed":8.459704357456454,"wind_direction":248.4991993580728,"air_pressure":1022.0,"humidity":65,"visibility":12.085048317823908,"predictability":75},{"id":5732991215075328,"weather_state_name":"Heavy Rain","weather_state_abbr":"hr","wind_direction_compass":"SW","created":"2020-02-16T21:16:02.545288Z","applicable_date":"2020-02-20","min_temp":4.5600000000000005,"max_temp":10.68,"the_temp":10.57,"wind_speed":13.765395595288846,"wind_direction":221.34963261827178,"air_pressure":1006.5,"humidity":76,"visibility":8.279771136562474,"predictability":77},{"id":4536439230431232,"weather_state_name":"Heavy Rain","weather_state_abbr":"hr","wind_direction_compass":"SW","created":"2020-02-16T21:16:05.048358Z","applicable_date":"2020-02-21","min_temp":3.715,"max_temp":10.64,"the_temp":9.08,"wind_speed":10.950873896444763,"wind_direction":235.5,"air_pressure":1024.0,"humidity":64,"visibility":9.999726596675416,"predictability":77}],"time":"2020-02-16T23:12:07.044726Z","sun_rise":"2020-02-16T07:13:35.337034Z","sun_set":"2020-02-16T17:16:22.919932Z","timezone_name":"LMT","parent":{"title":"England","location_type":"Region / State / Province","woeid":24554868,"latt_long":"52.883560,-1.974060"},"sources":[{"title":"BBC","slug":"bbc","url":"http://www.bbc.co.uk/weather/","crawl_rate":360},{"title":"Forecast.io","slug":"forecast-io","url":"http://forecast.io/","crawl_rate":480},{"title":"HAMweather","slug":"hamweather","url":"http://www.hamweather.com/","crawl_rate":360},{"title":"Met Office","slug":"met-office","url":"http://www.metoffice.gov.uk/","crawl_rate":180},{"title":"OpenWeatherMap","slug":"openweathermap","url":"http://openweathermap.org/","crawl_rate":360},{"title":"Weather Underground","slug":"wunderground","url":"https://www.wunderground.com/?apiref=fc30dc3cd224e19b","crawl_rate":720},{"title":"World Weather Online","slug":"world-weather-online","url":"http://www.worldweatheronline.com/","crawl_rate":360}],"title":"London","location_type":"City","woeid":44418,"latt_long":"51.506321,-0.12714","timezone":"Europe/London"}