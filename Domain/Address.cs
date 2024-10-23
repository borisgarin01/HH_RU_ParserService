using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Domain
{
    public sealed record Address
    {
        [JsonProperty("city", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonProperty("street", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonProperty("building", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("building")]
        public string Building { get; set; }

        [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lat")]
        public double? Lat { get; set; }

        [JsonProperty("lng", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lng")]
        public double? Lng { get; set; }

        [JsonProperty("raw", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("raw")]
        public string Raw { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}