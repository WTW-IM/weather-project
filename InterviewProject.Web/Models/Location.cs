using System.Text.Json.Serialization;

namespace InterviewProject
{
    public class Location
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("location_type")]
        public string LocationType { get; set; }
        [JsonPropertyName("woeid")]
        public int Woeid { get; set; }
        [JsonPropertyName("latt_long")]
        public string LatLong { get; set; }
    }
}

//    {
//title: "San Francisco",
//location_type: "City",
//woeid: 2487956,
//latt_long: "37.777119, -122.41964"
//},