using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Domain
{
    public sealed record LogoUrls
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonProperty("original", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("original")]
        public string Original { get; set; }

        [JsonProperty("90", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("90")]
        public string _90 { get; set; }

        [JsonProperty("240", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("240")]
        public string _240 { get; set; }
    }


}