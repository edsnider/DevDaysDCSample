using Newtonsoft.Json;

namespace DevDaysDCSample.Models
{
    public class Venue
    {
        public string Id { get; set; }
        public string Name { get; set; } 
        [JsonProperty("location")] 
        public VenueAddress Address { get; set; }
    }

    public class VenueAddress
    { 
        public string Address { get; set; } 
        public string City { get; set; } 
        public string State { get; set; } 
        [JsonProperty("lat")] 
        public double Latitude { get; set; } 
        [JsonProperty("lng")] 
        public double Longitude { get; set; } 
        public override string ToString()
        { 
            return $"{Address}, {City} {State}"; 
        } 
     } 
}
