using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Domain
{
    public sealed record Branding
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonProperty("tariff", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("tariff")]
        public string Tariff { get; set; }
    }


}